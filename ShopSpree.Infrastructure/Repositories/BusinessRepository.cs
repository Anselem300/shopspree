using MongoDB.Driver;
using ShopSpree.Core.Models;
using ShopSpree.Infrastructure.Data;

namespace ShopSpree.Infrastructure.Repositories;

public class BusinessRepository : IBusinessRepository
{
    private readonly MongoDbContext _context;

    public BusinessRepository(MongoDbContext context)
    {
        _context = context;
    }

    public async Task<List<Business>> GetAllAsync()
    {
        return await _context.Businesses
            .Find(_ => true)
            .ToListAsync();
    }

    public async Task<Business?> GetByIdAsync(string id)
    {
        return await _context.Businesses
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Business>> GetByOwnerAsync(string ownerId)
    {
        return await _context.Businesses
            .Find(x => x.OwnerId == ownerId)
            .ToListAsync();
    }

    public async Task CreateAsync(Business business)
    {
        await _context.Businesses.InsertOneAsync(business);
    }

    public async Task UpdateAsync(Business business)
{
    var result =
        await _context.Businesses.ReplaceOneAsync(
            x => x.Id == business.Id,
            business);

    Console.WriteLine(
        $"Matched: {result.MatchedCount}");

    Console.WriteLine(
        $"Modified: {result.ModifiedCount}");
}

    public async Task DeleteAsync(string id)
    {
        await _context.Businesses.DeleteOneAsync(
            x => x.Id == id);
    }
}