using Cinema.Entity;
using Cinema.Interfaces.Repositories;
using Cinema.Interfaces.Services;

namespace Cinema.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Movie> GetAll() => _repository.GetAll();

        public Movie? GetById(int id) => _repository.GetById(id);

        public Movie Add(Movie movie) => _repository.Add(movie);

        public void Update(Movie movie) => _repository.Update(movie);

        public void Delete(int id) => _repository.Delete(id);
    }
}
