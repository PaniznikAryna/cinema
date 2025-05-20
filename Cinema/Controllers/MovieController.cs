using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cinema.Entity;
using Cinema.Interfaces.Services;

namespace Cinema.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Movie> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Movie> GetById(int id)
        {
            var movie = _service.GetById(id);
            return movie == null ? NotFound() : Ok(movie);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        public ActionResult<Movie> Add(Movie movie)
        {
            var newMovie = _service.Add(movie);
            return CreatedAtAction(nameof(GetById), new { id = newMovie.Id }, newMovie);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Администратор,Кассир")]
        public IActionResult Update(int id, Movie movie)
        {
            if (id != movie.Id)
                return BadRequest();

            _service.Update(movie);
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
