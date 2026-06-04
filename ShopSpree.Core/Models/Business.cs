namespace ShopSpree.Core.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Business
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; } =
        Guid.NewGuid().ToString();

    public string OwnerId { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public double AverageRating { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}