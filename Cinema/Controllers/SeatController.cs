using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Seat> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Seat> GetById(int id)
        {
            var seat = _service.GetById(id);
            return seat == null ? NotFound() : Ok(seat);
        }

        [HttpPost]
        public ActionResult<Seat> Add(Seat seat)
        {
            var newSeat = _service.Add(seat);
            return CreatedAtAction(nameof(GetById), new { id = newSeat.Id }, newSeat);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Seat seat)
        {
            if (id != seat.Id) return BadRequest();
            _service.Update(seat);
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
