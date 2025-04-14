using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Entity
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [Column("Session_id")]
        public int SessionId { get; set; }
        public Session Session { get; set; } = null!;

        [Required]
        [Column("Seat_id")]
        public int SeatId { get; set; }
        public Seat Seat { get; set; } = null!;


        [Required]
        [Column("Purchase_date")]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [Column("User_id")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;


    }
}
