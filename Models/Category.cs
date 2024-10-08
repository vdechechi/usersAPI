using System.ComponentModel.DataAnnotations;

namespace BALTACRUD.Models;

public class Category
{
    [Key]

    public int Id { get; set; }


    [Required]
    [MaxLength(60)]
    [MinLength(1)]
    public string Title { get; set; }
}
