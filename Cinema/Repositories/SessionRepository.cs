using Cinema.Entity;
using Cinema.Interfaces.Repositories;
using Cinema.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly CinemaContext _context;

        public SessionRepository(CinemaContext context)
        {
            _context = context;
        }

        public IEnumerable<Session> GetAll()
        {
            return _context.Sessions.ToList();
        }

        public Session? GetById(int id)
        {
            return _context.Sessions.FirstOrDefault(session => session.Id == id);
        }


        public Session Add(Session session)
        {
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return session;
        }

        public void Update(Session session)
        {
            _context.Sessions.Update(session);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var sessionToDelete = _context.Sessions.FirstOrDefault(session => session.Id == id);
            if (sessionToDelete != null)
            {
                _context.Sessions.Remove(sessionToDelete);
                _context.SaveChanges();
            }
        }
    }
}
