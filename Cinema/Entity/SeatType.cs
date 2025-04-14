using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Entity
{
    public class SeatType
    {
        public int Id { get; set; }

        [Required]
        [Column("Type_name")]
        public string TypeName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "numeric(10,2)")]
        public decimal Price { get; set; }
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();

    }
}
