using Cinema.Entity;


namespace Cinema.Interfaces.Repositories

{
    public interface IHallRepository
    {
        IEnumerable<Hall> GetAll();
        Hall? GetById(int id);
        Hall Add(Hall hall);
        void Update(Hall hall);
        void Delete(int id);
    }
}
