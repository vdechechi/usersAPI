﻿using System.ComponentModel.DataAnnotations;

namespace BALTACRUD.Models;
public class Product
{

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(60)]
    [MinLength(1)]
    public string Title { get; set; }

    [MaxLength(1024)]
    public string Description { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public decimal Price { get; set; }

    public Category? Category { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int CategoryId { get; set; }
}

