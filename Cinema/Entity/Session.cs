using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cinema.Entity
{
    [Table("Session")]

    public class Session
    {
        public int Id { get; set; }

        [Required]
        [Column("Movie_id")]
        public int MovieId { get; set; }

        [Required]
        [Column("Hall_id")]
        public int HallId { get; set; }

        [JsonIgnore] // Исключаем из обработки JSON
        public Movie Movie { get; set; } = null!;

        [JsonIgnore]
        public Hall Hall { get; set; } = null!;

        [Required]
        [Column("Start_time")]
        public DateTime StartTime { get; set; }

        [Required]
        [Column("End_time")]
        public DateTime EndTime { get; set; }
    }


}
