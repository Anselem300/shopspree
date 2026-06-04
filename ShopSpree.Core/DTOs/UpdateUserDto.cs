using System.ComponentModel.DataAnnotations;

namespace ShopSpree.Core.DTOs;

public class UpdateUserDto
{
    public string Id { get; set; } = string.Empty;

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public string ProfileImageUrl { get; set; } = string.Empty;
}