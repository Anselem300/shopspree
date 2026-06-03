using MongoDB.Bson.Serialization.Attributes;
using ShopSpree.Domain.Common;

namespace ShopSpree.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string? ProfileImageUrl { get; set; }

    public bool IsBusinessOwner { get; set; }

    public bool IsActive { get; set; } = true;

    [BsonIgnore]
    public string FullName => $"{FirstName} {LastName}";
}