using Cinema.Entity;
using Cinema.Interfaces.Repositories;
using Cinema.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly CinemaContext _context;

        public ParticipantRepository(CinemaContext context)
        {
            _context = context;
        }

        public IEnumerable<Participant> GetAll()
        {
            return _context.Participants.ToList();
        }

        public Participant? GetById(int id)
        {
            return _context.Participants.FirstOrDefault(participant => participant.Id == id);
        }


        public Participant Add(Participant participant)
        {
            _context.Participants.Add(participant);
            _context.SaveChanges();
            return participant;
        }

        public void Update(Participant participant)
        {
            _context.Participants.Update(participant);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var participantToDelete = _context.Participants.FirstOrDefault(participant => participant.Id == id);
            if (participantToDelete != null)
            {
                _context.Participants.Remove(participantToDelete);
                _context.SaveChanges();
            }
        }
    }
}
