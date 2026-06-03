using MongoDB.Driver;
using ShopSpree.Application.Interfaces;
using ShopSpree.Domain.Entities;

namespace ShopSpree.Infrastructure.Data.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly MongoContext _context;

    public ReviewRepository(MongoContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Review review)
    {
        await _context.Reviews.InsertOneAsync(review);
    }

    public async Task DeleteAsync(string reviewId)
    {
        await _context.Reviews.DeleteOneAsync(
            x => x.Id == reviewId);
    }

    public async Task<List<Review>> GetBusinessReviewsAsync(
        string businessId)
    {
        return await _context.Reviews
            .Find(x => x.BusinessId == businessId)
            .ToListAsync();
    }
}