using ShopSpree.Core.DTOs;
using ShopSpree.Core.Interfaces;
using ShopSpree.Core.Models;
using ShopSpree.Infrastructure.Repositories;

namespace ShopSpree.Infrastructure.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _repo;
    private readonly IBusinessRepository _businessRepo;

    public ReviewService(
        IReviewRepository repo,
        IBusinessRepository businessRepo)
    {
        _repo = repo;
        _businessRepo = businessRepo;
    }

    public Task<List<Review>> GetByBusinessAsync(string businessId)
        => _repo.GetByBusinessAsync(businessId);

    public async Task AddReviewAsync(
        ReviewDto dto,
        string userId,
        string userName)
    {
        var review = new Review
        {
            BusinessId = dto.BusinessId,
            UserId = userId,
            UserName = userName,
            Rating = dto.Rating,
            Comment = dto.Comment,
            CreatedAt = DateTime.UtcNow
        };

        await _repo.CreateAsync(review);

        // 🔥 IMPORTANT: update business rating
        var reviews = await _repo.GetByBusinessAsync(dto.BusinessId);

        var business = await _businessRepo.GetByIdAsync(dto.BusinessId);

        if (business is not null && reviews.Any())
        {
            business.AverageRating =
                reviews.Average(r => r.Rating);

            await _businessRepo.UpdateAsync(business);
        }
    }

    public Task DeleteAsync(string id)
        => _repo.DeleteAsync(id);
}