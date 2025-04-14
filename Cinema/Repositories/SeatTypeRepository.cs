using Cinema.Entity;
using Cinema.Interfaces.Repositories;
using Cinema.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repositories
{
    public class SeatTypeRepository : ISeatTypeRepository
    {
        private readonly CinemaContext _context;

        public SeatTypeRepository(CinemaContext context)
        {
            _context = context;
        }

        public IEnumerable<SeatType> GetAll()
        {
            return _context.SeatTypes.ToList();
        }

        public SeatType? GetById(int id)
        {
            return _context.SeatTypes.FirstOrDefault(seattype => seattype.Id == id);
        }


        public SeatType Add(SeatType seattype)
        {
            _context.SeatTypes.Add(seattype);
            _context.SaveChanges();
            return seattype;
        }

        public void Update(SeatType seattype)
        {
            _context.SeatTypes.Update(seattype);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var seattypeToDelete = _context.SeatTypes.FirstOrDefault(seattype => seattype.Id == id);
            if (seattypeToDelete != null)
            {
                _context.SeatTypes.Remove(seattypeToDelete);
                _context.SaveChanges();
            }
        }
    }
}
