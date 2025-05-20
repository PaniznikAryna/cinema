using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cinema.Entity;
using Cinema.Interfaces.Services;

namespace Cinema.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _service;

        public GenreController(IGenreService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Genre> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Genre> GetById(int id)
        {
            var genre = _service.GetById(id);
            return genre == null ? NotFound() : Ok(genre);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        public ActionResult<Genre> Add(Genre genre)
        {
            var newGenre = _service.Add(genre);
            return CreatedAtAction(nameof(GetById), new { id = newGenre.Id }, newGenre);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Администратор")]
        public IActionResult Update(int id, Genre genre)
        {
            if (id != genre.Id)
                return BadRequest();

            _service.Update(genre);
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
