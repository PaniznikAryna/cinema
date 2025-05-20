using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Entity
{
    public class Seat
    {
        public int Id { get; set; }

        [Required]
        [Column("Hall_id")]
        public int HallId { get; set; }

        [Required]
        [Column("Row_number")]
        public int RowNumber { get; set; }

        [Required]
        [Column("Seat_number")]
        public int SeatNumber { get; set; }

        [Required]
        [Column("Seat_type_id")]
        public int SeatTypeId { get; set; }
        public Hall? Hall { get; set; }
        public SeatType? SeatType { get; set; }

    }
}
