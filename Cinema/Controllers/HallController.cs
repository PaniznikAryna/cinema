using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cinema.Entity;
using Cinema.Interfaces.Services;

namespace Cinema.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HallController : ControllerBase
    {
        private readonly IHallService _service;

        public HallController(IHallService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Hall> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Hall> GetById(int id)
        {
            var hall = _service.GetById(id);
            return hall == null ? NotFound() : Ok(hall);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        public ActionResult<Hall> Add(Hall hall)
        {
            var newHall = _service.Add(hall);
            return CreatedAtAction(nameof(GetById), new { id = newHall.Id }, newHall);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Администратор,Кассир")]
        public IActionResult Update(int id, Hall hall)
        {
            if (id != hall.Id)
                return BadRequest();

            _service.Update(hall);
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
