using Cinema.Entity;
using Cinema.Interfaces.Repositories;
using Cinema.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly CinemaContext _context;

        public SeatRepository(CinemaContext context)
        {
            _context = context;
        }

        public IEnumerable<Seat> GetAll()
        {
            return _context.Seats.ToList();
        }

        public Seat? GetById(int id)
        {
            return _context.Seats.FirstOrDefault(seat => seat.Id == id);
        }


        public Seat Add(Seat seat)
        {
            _context.Seats.Add(seat);
            _context.SaveChanges();
            return seat;
        }

        public void Update(Seat seat)
        {
            _context.Seats.Update(seat);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var seatToDelete = _context.Seats.FirstOrDefault(seat => seat.Id == id);
            if (seatToDelete != null)
            {
                _context.Seats.Remove(seatToDelete);
                _context.SaveChanges();
            }
        }
    }
}
