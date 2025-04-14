using Cinema.Entity;
using Cinema.Interfaces.Repositories;
using Cinema.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly CinemaContext _context;

        public TicketRepository(CinemaContext context)
        {
            _context = context;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _context.Tickets.ToList();
        }

        public Ticket? GetById(int id)
        {
            return _context.Tickets.FirstOrDefault(ticket => ticket.Id == id);
        }


        public Ticket Add(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return ticket;
        }

        public void Update(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ticketToDelete = _context.Tickets.FirstOrDefault(ticket => ticket.Id == id);
            if (ticketToDelete != null)
            {
                _context.Tickets.Remove(ticketToDelete);
                _context.SaveChanges();
            }
        }
    }
}
