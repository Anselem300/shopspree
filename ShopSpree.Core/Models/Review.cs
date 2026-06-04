namespace ShopSpree.Core.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


public class Review
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; } =
        Guid.NewGuid().ToString();

    public string BusinessId { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public int Rating { get; set; }

    public string Comment { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}