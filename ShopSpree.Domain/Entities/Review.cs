using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using ShopSpree.Domain.Common;
using ShopSpree.Domain.Enums;

namespace ShopSpree.Domain.Entities;

public class Review : BaseEntity
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string BusinessId { get; set; } = string.Empty;

    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; } = string.Empty;

    public Rating Rating { get; set; }

    public string Comment { get; set; } = string.Empty;

    public string ReviewerName { get; set; } = string.Empty;
}