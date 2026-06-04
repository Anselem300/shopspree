namespace ShopSpree.Core.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Category
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; } =
        Guid.NewGuid().ToString();

    public string Name { get; set; } = string.Empty;
}