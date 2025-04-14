using Cinema.Entity;
using Cinema.Interfaces.Repositories;
using Cinema.Interfaces.Services;

namespace Cinema.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;

        public GenreService(IGenreRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Genre> GetAll() => _repository.GetAll();

        public Genre? GetById(int id) => _repository.GetById(id);

        public Genre Add(Genre genre) => _repository.Add(genre);

        public void Update(Genre genre) => _repository.Update(genre);

        public void Delete(int id) => _repository.Delete(id);
    }
}
