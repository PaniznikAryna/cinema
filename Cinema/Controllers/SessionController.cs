using Microsoft.AspNetCore.Mvc;
using Cinema.Entity;
using Cinema.Interfaces.Services;
namespace Cinema.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _service;

        public SessionController(ISessionService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Session> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Session> GetById(int id)
        {
            var session = _service.GetById(id);
            return session == null ? NotFound() : Ok(session);
        }

        [HttpPost]
        public ActionResult<Session> Add(Session session)
        {
            var newSession = _service.Add(session);
            return CreatedAtAction(nameof(GetById), new { id = newSession.Id }, newSession);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Session session)
        {
            if (id != session.Id) return BadRequest();
            _service.Update(session);
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
