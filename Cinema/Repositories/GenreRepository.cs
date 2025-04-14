using Cinema.Entity;
using Cinema.Interfaces.Repositories;
using Cinema.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly CinemaContext _context;

        public GenreRepository(CinemaContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }

        public Genre? GetById(int id)
        {
            return _context.Genres.FirstOrDefault(genre => genre.Id == id);
        }


        public Genre Add(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return genre;
        }

        public void Update(Genre genre)
        {
            _context.Genres.Update(genre);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var genreToDelete = _context.Genres.FirstOrDefault(genre => genre.Id == id);
            if (genreToDelete != null)
            {
                _context.Genres.Remove(genreToDelete);
                _context.SaveChanges();
            }
        }
    }
}
