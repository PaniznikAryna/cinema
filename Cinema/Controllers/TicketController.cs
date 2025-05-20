using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;
using Cinema.Entity;
using Cinema.Interfaces.Services;
using Cinema.dto;

namespace Cinema.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }


        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Ticket>> GetAll()
        {
            if (User.IsInRole("Кассир") || User.IsInRole("Администратор"))
            {
                return Ok(_service.GetAll());
            }
            else
            {
                int currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var tickets = _service.GetAll().Where(t => t.UserId == currentUserId);
                return Ok(tickets);
            }
        }


        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Ticket> GetById(int id)
        {
            var ticket = _service.GetById(id);
            if (ticket == null)
                return NotFound();

            if (User.IsInRole("Кассир") || User.IsInRole("Администратор"))
            {
                return Ok(ticket);
            }
            else
            {
                int currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (ticket.UserId == currentUserId)
                    return Ok(ticket);
                else
                    return Forbid();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Кассир,Администратор")]
        public ActionResult<Ticket> Add(CreateTicketDto dto)
        {
            var ticket = new Ticket
            {
                SessionId = dto.SessionId,
                SeatId = dto.SeatId,
                PurchaseDate = dto.PurchaseDate,
                UserId = dto.UserId
            };

            var newTicket = _service.Add(ticket);
            return CreatedAtAction(nameof(GetById), new { id = newTicket.Id }, newTicket);
        }



        [HttpPut("{id}")]
        [Authorize(Roles = "Администратор")]
        public IActionResult Update(int id, Ticket ticket)
        {
            if (id != ticket.Id)
                return BadRequest();

            _service.Update(ticket);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var ticket = _service.GetById(id);
            if (ticket == null)
                return NotFound();

            if (User.IsInRole("Кассир") || User.IsInRole("Администратор"))
            {
                _service.Delete(id);
                return NoContent();
            }
            else
            {
                int currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (ticket.UserId == currentUserId)
                {
                    _service.Delete(id);
                    return NoContent();
                }
                else
                {
                    return Forbid();
                }
            }
        }
    }
}
