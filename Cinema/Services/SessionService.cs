using Cinema.Entity;
using Cinema.Interfaces.Repositories;
using Cinema.Interfaces.Services;

namespace Cinema.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _repository;

        public SessionService(ISessionRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Session> GetAll() => _repository.GetAll();

        public Session? GetById(int id) => _repository.GetById(id);

        public Session Add(Session session) => _repository.Add(session);

        public void Update(Session session) => _repository.Update(session);

        public void Delete(int id) => _repository.Delete(id);
    }
}
