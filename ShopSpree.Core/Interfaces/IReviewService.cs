using ShopSpree.Core.DTOs;
using ShopSpree.Core.Models;

namespace ShopSpree.Core.Interfaces;

public interface IReviewService
{
    Task<List<Review>> GetByBusinessAsync(string businessId);

    Task AddReviewAsync(ReviewDto dto, string userId, string userName);

    Task DeleteAsync(string id);
}