using Cinema.Entity;
using Cinema.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<Participant> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Participant> GetById(int id)
        {
            var participant = _service.GetById(id);
            return participant == null ? NotFound() : Ok(participant);
        }

        [HttpPost]
        public ActionResult<Participant> Add(Participant participant)
        {
            var newParticipant = _service.Add(participant);
            return CreatedAtAction(nameof(GetById), new { id = newParticipant.Id }, newParticipant);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Participant participant)
        {
            if (id != participant.Id) return BadRequest();
            _service.Update(participant);
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
