using Cinema.Entity;

namespace Cinema.Interfaces.Repositories
{
    public interface IParticipantRepository
    {
        IEnumerable<Participant> GetAll();
        Participant? GetById(int id);
        Participant Add(Participant participant);
        void Update(Participant participant);
        void Delete(int id);
    }
}
