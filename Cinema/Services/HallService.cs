using Cinema.Entity;
using Cinema.Interfaces.Repositories;
using Cinema.Interfaces.Services;

namespace Cinema.Services
{
    public class HallService : IHallService
    {
        private readonly IHallRepository _repository;

        public HallService(IHallRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Hall> GetAll() => _repository.GetAll();

        public Hall? GetById(int id) => _repository.GetById(id);

        public Hall Add(Hall hall) => _repository.Add(hall);

        public void Update(Hall hall) => _repository.Update(hall);

        public void Delete(int id) => _repository.Delete(id);
    }
}
