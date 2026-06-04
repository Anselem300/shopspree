using ShopSpree.Core.Models;

namespace ShopSpree.Infrastructure.Repositories;

public interface IReviewRepository
{
    Task<List<Review>> GetByBusinessAsync(string businessId);

    Task CreateAsync(Review review);

    Task DeleteAsync(string id);
}