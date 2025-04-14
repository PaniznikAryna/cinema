using Cinema.Entity;

namespace Cinema.Interfaces.Repositories

{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAll();
        Genre? GetById(int id);
        Genre Add(Genre genre);
        void Update(Genre genre);
        void Delete(int id);
    }
}
