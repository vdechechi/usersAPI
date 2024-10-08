using System.ComponentModel.DataAnnotations;

namespace BALTACRUD.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(1)]

        public string Username { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(1)]

        public string Password { get; set; }

        public string Role { get; set; }

    }
}
