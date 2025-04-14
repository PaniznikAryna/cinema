using Cinema.Entity;
namespace Cinema.Interfaces.Services
{
    public interface ISeatService
    {
        IEnumerable<Seat> GetAll();
        Seat? GetById(int id);
        Seat Add(Seat seat);
        void Update(Seat seat);
        void Delete(int id);
    }
}
