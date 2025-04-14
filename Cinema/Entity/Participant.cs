using System.ComponentModel.DataAnnotations;

namespace Cinema.Entity
{
    public class Participant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
