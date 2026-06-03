namespace ShopSpree.Application.DTOs;

public class BusinessDto
{
    public string Id { get; set; } = string.Empty;

    public string OwnerId { get; set; } = string.Empty;

    public string CategoryId { get; set; } = string.Empty;

    public string BusinessName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string BusinessType { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? Website { get; set; }

    public string Address { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public List<string> ImageUrls { get; set; } = new();

    public double AverageRating { get; set; }

    public int TotalReviews { get; set; }

    public bool IsFeatured { get; set; }

    public string FullAddress =>
        $"{Address}, {City}, {State}, {Country}";
}