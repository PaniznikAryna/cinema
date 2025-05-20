using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cinema.Entity;
using Cinema.Interfaces.Services;

namespace Cinema.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _service;

        public ParticipantController(IParticipantService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Participant> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Participant> GetById(int id)
        {
            var participant = _service.GetById(id);
            return participant == null ? NotFound() : Ok(participant);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        public ActionResult<Participant> Add(Participant participant)
        {
            var newParticipant = _service.Add(participant);
            return CreatedAtAction(nameof(GetById), new { id = newParticipant.Id }, newParticipant);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Администратор")]
        public IActionResult Update(int id, Participant participant)
        {
            if (id != participant.Id)
                return BadRequest();

            _service.Update(participant);
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
