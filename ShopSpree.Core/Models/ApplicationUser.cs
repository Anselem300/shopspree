namespace ShopSpree.Core.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


public class ApplicationUser
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; } =
        Guid.NewGuid().ToString();

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string ProfileImageUrl { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}