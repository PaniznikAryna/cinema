using Cinema.Entity;
using Cinema.Interfaces.Repositories;
using Cinema.Interfaces.Services;

namespace Cinema.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _repository;

        public ParticipantService(IParticipantRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Participant> GetAll() => _repository.GetAll();

        public Participant? GetById(int id) => _repository.GetById(id);

        public Participant Add(Participant participant) => _repository.Add(participant);

        public void Update(Participant participant) => _repository.Update(participant);

        public void Delete(int id) => _repository.Delete(id);
    }
}
