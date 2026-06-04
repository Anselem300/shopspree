using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ShopSpree.Core.Models;
using ShopSpree.Infrastructure.Configurations;

namespace ShopSpree.Infrastructure.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(
        IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(
            settings.Value.ConnectionString);

        _database = client.GetDatabase(
            settings.Value.DatabaseName);
    }

    public IMongoCollection<ApplicationUser> Users =>
        _database.GetCollection<ApplicationUser>("Users");

    public IMongoCollection<Business> Businesses =>
        _database.GetCollection<Business>("Businesses");

    public IMongoCollection<Review> Reviews =>
        _database.GetCollection<Review>("Reviews");

    public IMongoCollection<Category> Categories =>
        _database.GetCollection<Category>("Categories");
}