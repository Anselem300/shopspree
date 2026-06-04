using MongoDB.Driver;
using ShopSpree.Core.Models;
using ShopSpree.Infrastructure.Data;

namespace ShopSpree.Infrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly MongoDbContext _context;

    public ReviewRepository(MongoDbContext context)
    {
        _context = context;
    }

    public async Task<List<Review>> GetByBusinessAsync(
        string businessId)
    {
        return await _context.Reviews
            .Find(x => x.BusinessId == businessId)
            .ToListAsync();
    }

    public async Task CreateAsync(Review review)
    {
        await _context.Reviews.InsertOneAsync(review);
    }

    public async Task DeleteAsync(string id)
    {
        await _context.Reviews.DeleteOneAsync(
            x => x.Id == id);
    }
}