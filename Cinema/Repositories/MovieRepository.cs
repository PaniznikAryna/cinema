using Cinema.Entity;
using Cinema.Interfaces.Repositories;

namespace Cinema.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly List<Movie> _movies = new();

        public IEnumerable<Movie> GetAll() => _movies;

        public Movie? GetById(int id) => _movies.FirstOrDefault(m => m.Id == id);

        public Movie Add(Movie movie)
        {
            movie.Id = _movies.Count > 0 ? _movies.Max(m => m.Id) + 1 : 1;
            _movies.Add(movie);
            return movie;
        }

        public void Update(Movie movie)
        {
            var existingMovie = GetById(movie.Id);
            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.Duration = movie.Duration;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.Country = movie.Country;
                existingMovie.AgeRestriction = movie.AgeRestriction;
                existingMovie.GenreIds = movie.GenreIds;
                existingMovie.ParticipantIds = movie.ParticipantIds;
                existingMovie.SessionIds = movie.SessionIds;
            }
        }

        public void Delete(int id)
        {
            var movie = GetById(id);
            if (movie != null) _movies.Remove(movie);
        }
    }
}
