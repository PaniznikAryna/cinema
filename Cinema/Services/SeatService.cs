using Cinema.Entity;
using Cinema.Interfaces.Repositories;
using Cinema.Interfaces.Services;

namespace Cinema.Services
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _repository;

        public SeatService(ISeatRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Seat> GetAll() => _repository.GetAll();

        public Seat? GetById(int id) => _repository.GetById(id);

        public Seat Add(Seat seat) => _repository.Add(seat);

        public void Update(Seat seat) => _repository.Update(seat);

        public void Delete(int id) => _repository.Delete(id);
    }
}
