using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Movie> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Movie> GetById(int id)
        {
            var movie = _service.GetById(id);
            return movie == null ? NotFound() : Ok(movie);
        }

        [HttpPost]
        public ActionResult<Movie> Add(Movie movie)
        {
            var newMovie = _service.Add(movie);
            return CreatedAtAction(nameof(GetById), new { id = newMovie.Id }, newMovie);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Movie movie)
        {
            if (id != movie.Id) return BadRequest();
            _service.Update(movie);
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
