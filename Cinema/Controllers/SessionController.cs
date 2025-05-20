using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cinema.Entity;
using Cinema.Interfaces.Services;
using Cinema.dto;

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
        [AllowAnonymous]
        public IEnumerable<Session> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Session> GetById(int id)
        {
            var session = _service.GetById(id);
            return session == null ? NotFound() : Ok(session);
        }

        [HttpPost]
        [Authorize(Roles = "Кассир,Администратор")]
        public ActionResult<Session> Add(CreateSessionDto dto)
        {
            var session = new Session
            {
                MovieId = dto.MovieId,
                HallId = dto.HallId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime
            };

            var newSession = _service.Add(session);
            return CreatedAtAction(nameof(GetById), new { id = newSession.Id }, newSession);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Кассир,Администратор")]
        public IActionResult Update(int id, Session session)
        {
            if (id != session.Id)
                return BadRequest();

            _service.Update(session);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Кассир,Администратор")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
