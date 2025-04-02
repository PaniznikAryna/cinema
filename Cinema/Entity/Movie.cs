using System.ComponentModel.DataAnnotations;

namespace Cinema.Entity
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int Duration { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Country { get; set; } = string.Empty;

        [Required]
        public int AgeRestriction { get; set; }

        [Required]
        public List<int> GenreIds { get; set; } = new();

        [Required]
        public List<int> ParticipantIds { get; set; } = new();

        public List<int> SessionIds { get; set; } = new();
    }
}
