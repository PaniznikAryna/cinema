using Cinema.Entity;
using Cinema.Interfaces.Repositories;
using Cinema.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaContext _context;

        public MovieRepository(CinemaContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie? GetById(int id)
        {
            return _context.Movies.FirstOrDefault(movie => movie.Id == id);
        }


        public Movie Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        public void Update(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movieToDelete = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movieToDelete != null)
            {
                _context.Movies.Remove(movieToDelete);
                _context.SaveChanges();
            }
        }
    }
}
