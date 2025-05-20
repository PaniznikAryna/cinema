using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cinema.Entity;
using Cinema.Interfaces.Services;

namespace Cinema.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _service;

        public SeatController(ISeatService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Seat> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Seat> GetById(int id)
        {
            var seat = _service.GetById(id);
            return seat == null ? NotFound() : Ok(seat);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        public ActionResult<Seat> Add(Seat seat)
        {
            var newSeat = _service.Add(seat);
            return CreatedAtAction(nameof(GetById), new { id = newSeat.Id }, newSeat);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Администратор,Кассир")]
        public IActionResult Update(int id, Seat seat)
        {
            if (id != seat.Id)
                return BadRequest();

            _service.Update(seat);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Администратор")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
