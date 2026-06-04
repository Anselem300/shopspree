using System.ComponentModel.DataAnnotations;

namespace ShopSpree.Core.DTOs;

public class ReviewDto
{
    [Required]
    public string BusinessId { get; set; } = string.Empty;

    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }

    [Required]
    [StringLength(500)]
    public string Comment { get; set; } = string.Empty;
}