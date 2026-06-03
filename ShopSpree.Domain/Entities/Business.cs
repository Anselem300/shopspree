using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ShopSpree.Domain.Common;
using ShopSpree.Domain.Enums;

namespace ShopSpree.Domain.Entities;

public class Business : BaseEntity
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string OwnerId { get; set; } = string.Empty;

    [BsonRepresentation(BsonType.ObjectId)]
    public string CategoryId { get; set; } = string.Empty;

    public string BusinessName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public BusinessType BusinessType { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? Website { get; set; }

    public string Address { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public List<string> ImageUrls { get; set; } = new();

    public bool IsApproved { get; set; } = true;

    public bool IsFeatured { get; set; } = false;

    public double AverageRating { get; set; } = 0;

    public int TotalReviews { get; set; } = 0;

    [BsonIgnore]
    public string FullAddress =>
        $"{Address}, {City}, {State}, {Country}";
}