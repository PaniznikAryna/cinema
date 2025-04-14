using Cinema.Entity;

namespace Cinema.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetAll();
        Ticket? GetById(int id);
        Ticket Add(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(int id);
    }
}
