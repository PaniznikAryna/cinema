using Cinema.Entity;
using Cinema.Interfaces.Repositories;
using Cinema.Interfaces.Services;
using System.Net.Sockets;

namespace Cinema.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;

        public TicketService(ITicketRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Ticket> GetAll() => _repository.GetAll();

        public Ticket? GetById(int id) => _repository.GetById(id);

        public Ticket Add(Ticket ticket) => _repository.Add(ticket);

        public void Update(Ticket ticket) => _repository.Update(ticket);

        public void Delete(int id) => _repository.Delete(id);
    }
}
