using System.ComponentModel.DataAnnotations;

namespace Cinema.Entity
{
    public class Hall
    {
        public int Id { get; set; }
        
        [Required]
        public int Number { get; set; }

        [Required]
        public int Capacity { get; set; }

        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    }
}
