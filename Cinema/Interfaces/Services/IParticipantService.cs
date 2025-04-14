using Cinema.Entity;

namespace Cinema.Interfaces.Services
{
    public interface IParticipantService
    {
        IEnumerable<Participant> GetAll();
        Participant? GetById(int id);
        Participant Add(Participant participant);
        void Update(Participant participant);
        void Delete(int id);
    }
}
