using Microsoft.AspNetCore.Mvc;
using Cinema.Entity;
using Cinema.Interfaces.Services;
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
        public IEnumerable<Ticket> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Ticket> GetById(int id)
        {
            var ticket = _service.GetById(id);
            return ticket == null ? NotFound() : Ok(ticket);
        }

        [HttpPost]
        public ActionResult<Ticket> Add(Ticket ticket)
        {
            var newTicket = _service.Add(ticket);
            return CreatedAtAction(nameof(GetById), new { id = newTicket.Id }, newTicket);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Ticket ticket)
        {
            if (id != ticket.Id) return BadRequest();
            _service.Update(ticket);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
