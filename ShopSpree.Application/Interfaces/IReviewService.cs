using ShopSpree.Application.DTOs;

namespace ShopSpree.Application.Interfaces;

public interface IReviewService
{
    Task<IEnumerable<ReviewDto>> GetBusinessReviewsAsync(string businessId);

    Task<bool> AddReviewAsync(ReviewDto review);

    Task<bool> DeleteReviewAsync(string reviewId);
}