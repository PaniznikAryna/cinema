using Cinema.Entity;
using Cinema.Interfaces.Repositories;
using Cinema.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repositories
{
    public class HallRepository : IHallRepository
    {
        private readonly CinemaContext _context;

        public HallRepository(CinemaContext context)
        {
            _context = context;
        }

        public IEnumerable<Hall> GetAll()
        {
            return _context.Halls.ToList();
        }

        public Hall? GetById(int id)
        {
            return _context.Halls.FirstOrDefault(hall => hall.Id == id);
        }


        public Hall Add(Hall hall)
        {
            _context.Halls.Add(hall);
            _context.SaveChanges();
            return hall;
        }

        public void Update(Hall hall)
        {
            _context.Halls.Update(hall);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var hallToDelete = _context.Halls.FirstOrDefault(hall => hall.Id == id);
            if (hallToDelete != null)
            {
                _context.Halls.Remove(hallToDelete);
                _context.SaveChanges();
            }
        }
    }
}
