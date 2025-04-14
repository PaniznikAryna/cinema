using Cinema.Entity;
using Cinema.Interfaces.Repositories;
using Cinema.Interfaces.Services;

namespace Cinema.Services
{
    public class SeatTypeService : ISeatTypeService
    {
        private readonly ISeatTypeRepository _repository;

        public SeatTypeService(ISeatTypeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<SeatType> GetAll() => _repository.GetAll();

        public SeatType? GetById(int id) => _repository.GetById(id);

        public SeatType Add(SeatType seattype) => _repository.Add(seattype);

        public void Update(SeatType seattype) => _repository.Update(seattype);

        public void Delete(int id) => _repository.Delete(id);
    }
}
