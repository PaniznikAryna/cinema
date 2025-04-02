using Cinema.Entity;

namespace Cinema.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie? GetById(int id);
        Movie Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
}
