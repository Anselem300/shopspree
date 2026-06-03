using ShopSpree.Domain.Entities;

namespace ShopSpree.Application.Interfaces;

public interface IReviewRepository
{
    Task<List<Review>> GetBusinessReviewsAsync(string businessId);
    Task CreateAsync(Review review);
    Task DeleteAsync(string reviewId);
}