using Cinema.Entity;

namespace Cinema.Interfaces.Services
{
    public interface IHallService
    {
        IEnumerable<Hall> GetAll();
        Hall? GetById(int id);
        Hall Add(Hall hall);
        void Update(Hall hall);
        void Delete(int id);
    }
}
