using ShopSpree.Application.DTOs;
using ShopSpree.Application.Interfaces;
using ShopSpree.Domain.Entities;
using ShopSpree.Domain.Enums;

namespace ShopSpree.Application.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(
        IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<IEnumerable<ReviewDto>>
        GetBusinessReviewsAsync(string businessId)
    {
        var reviews =
            await _reviewRepository.GetBusinessReviewsAsync(businessId);

        return reviews.Select(MapToDto);
    }

    public async Task<bool> AddReviewAsync(
        ReviewDto reviewDto)
    {
        var review = new Review
        {
            BusinessId = reviewDto.BusinessId,
            UserId = reviewDto.UserId,
            ReviewerName = reviewDto.ReviewerName,
            Comment = reviewDto.Comment,
            Rating = (Rating)reviewDto.Rating
        };

        await _reviewRepository.CreateAsync(review);

        return true;
    }

    public async Task<bool> DeleteReviewAsync(
        string reviewId)
    {
        await _reviewRepository.DeleteAsync(reviewId);

        return true;
    }

    private static ReviewDto MapToDto(Review review)
    {
        return new ReviewDto
        {
            Id = review.Id,
            BusinessId = review.BusinessId,
            UserId = review.UserId,
            ReviewerName = review.ReviewerName,
            Comment = review.Comment,
            Rating = (int)review.Rating,
            CreatedAt = review.CreatedAt
        };
    }
}