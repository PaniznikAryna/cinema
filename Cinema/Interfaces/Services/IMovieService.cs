using Cinema.Entity;

namespace Cinema.Interfaces.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();
        Movie? GetById(int id);
        Movie Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
}
