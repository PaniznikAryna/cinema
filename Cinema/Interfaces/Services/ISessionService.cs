using Cinema.Entity;

namespace Cinema.Interfaces.Services
{
    public interface ISessionService
    {
        IEnumerable<Session> GetAll();
        Session? GetById(int id);
        Session Add(Session session);
        void Update(Session session);
        void Delete(int id);
    }
}
