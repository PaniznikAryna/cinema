using Microsoft.AspNetCore.Mvc;
using Cinema.Entity;
using Cinema.Interfaces.Services;
namespace Cinema.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeatTypeController : ControllerBase
    {
        private readonly ISeatTypeService _service;

        public SeatTypeController(ISeatTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<SeatType> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<SeatType> GetById(int id)
        {
            var seattype = _service.GetById(id);
            return seattype == null ? NotFound() : Ok(seattype);
        }

        [HttpPost]
        public ActionResult<SeatType> Add(SeatType seattype)
        {
            var newSeatType = _service.Add(seattype);
            return CreatedAtAction(nameof(GetById), new { id = newSeatType.Id }, newSeatType);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SeatType seattype)
        {
            if (id != seattype.Id) return BadRequest();
            _service.Update(seattype);
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
