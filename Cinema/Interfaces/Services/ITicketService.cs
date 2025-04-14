using Cinema.Entity;

namespace Cinema.Interfaces.Services
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetAll();
        Ticket? GetById(int id);
        Ticket Add(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(int id);
    }
}
