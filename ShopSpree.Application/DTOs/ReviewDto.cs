namespace ShopSpree.Application.DTOs;

public class ReviewDto
{
    public string Id { get; set; } = string.Empty;

    public string BusinessId { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public string ReviewerName { get; set; } = string.Empty;

    public int Rating { get; set; }

    public string Comment { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}