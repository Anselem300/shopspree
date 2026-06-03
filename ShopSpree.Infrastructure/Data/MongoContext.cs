using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ShopSpree.Domain.Entities;

namespace ShopSpree.Infrastructure.Data;

public class MongoContext
{
    private readonly IMongoDatabase _database;

    public MongoContext(IConfiguration configuration)
    {
        var connectionString =
            configuration["MongoDbSettings:ConnectionString"];

        var databaseName =
            configuration["MongoDbSettings:DatabaseName"];

        var client = new MongoClient(connectionString);

        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<User> Users =>
        _database.GetCollection<User>("Users");

    public IMongoCollection<Business> Businesses =>
        _database.GetCollection<Business>("Businesses");

    public IMongoCollection<Review> Reviews =>
        _database.GetCollection<Review>("Reviews");

    public IMongoCollection<Category> Categories =>
        _database.GetCollection<Category>("Categories");
}