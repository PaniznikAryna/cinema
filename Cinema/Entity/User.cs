using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Entity
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;


        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column("Date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Column("position")]
        public string Position { get; set; } = "user";


    }
}
