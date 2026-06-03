using ShopSpree.Application.DTOs;
using ShopSpree.Application.Interfaces;
using ShopSpree.Domain.Entities;
using ShopSpree.Domain.Enums;
using ShopSpree.Shared.Business;

namespace ShopSpree.Application.Services;

public class BusinessService : IBusinessService
{
    private readonly IBusinessRepository _businessRepository;

    public BusinessService(
        IBusinessRepository businessRepository)
    {
        _businessRepository = businessRepository;
    }

    public async Task<IEnumerable<BusinessDto>> GetAllAsync()
    {
        var businesses =
            await _businessRepository.GetAllAsync();

        return businesses.Select(MapToDto);
    }

    public async Task<BusinessDto?> GetByIdAsync(string id)
    {
        var business =
            await _businessRepository.GetByIdAsync(id);

        return business is null ? null : MapToDto(business);
    }

    public async Task<IEnumerable<BusinessDto>> SearchAsync(
        string keyword)
    {
        var businesses =
            await _businessRepository.SearchAsync(keyword);

        return businesses.Select(MapToDto);
    }

    public async Task<IEnumerable<BusinessDto>> FilterByCategoryAsync(
        string categoryId)
    {
        var businesses =
            await _businessRepository.GetByCategoryAsync(categoryId);

        return businesses.Select(MapToDto);
    }

    public async Task<IEnumerable<BusinessDto>> FilterByLocationAsync(
        string city)
    {
        var businesses =
            await _businessRepository.GetByLocationAsync(city);

        return businesses.Select(MapToDto);
    }

    public async Task<bool> CreateAsync(
        CreateBusinessRequest request,
        string ownerId)
    {
        var business = new Business
        {
            OwnerId = ownerId,
            CategoryId = request.CategoryId,
            BusinessName = request.BusinessName,
            Description = request.Description,
            BusinessType = Enum.Parse<BusinessType>(request.BusinessType),
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            Website = request.Website,
            Address = request.Address,
            City = request.City,
            State = request.State,
            Country = request.Country,
            ImageUrls = request.ImageUrls
        };

        await _businessRepository.CreateAsync(business);

        return true;
    }

    public async Task<bool> UpdateAsync(
        UpdateBusinessRequest request)
    {
        var business =
            await _businessRepository.GetByIdAsync(request.Id);

        if (business is null)
            return false;

        business.BusinessName = request.BusinessName;
        business.Description = request.Description;
        business.CategoryId = request.CategoryId;
        business.BusinessType =
            Enum.Parse<BusinessType>(request.BusinessType);
        business.PhoneNumber = request.PhoneNumber;
        business.Email = request.Email;
        business.Website = request.Website;
        business.Address = request.Address;
        business.City = request.City;
        business.State = request.State;
        business.Country = request.Country;
        business.ImageUrls = request.ImageUrls;
        business.UpdatedAt = DateTime.UtcNow;

        await _businessRepository.UpdateAsync(business);

        return true;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        await _businessRepository.DeleteAsync(id);
        return true;
    }

    private static BusinessDto MapToDto(Business business)
    {
        return new BusinessDto
        {
            Id = business.Id,
            OwnerId = business.OwnerId,
            CategoryId = business.CategoryId,
            BusinessName = business.BusinessName,
            Description = business.Description,
            BusinessType = business.BusinessType.ToString(),
            PhoneNumber = business.PhoneNumber,
            Email = business.Email,
            Website = business.Website,
            Address = business.Address,
            City = business.City,
            State = business.State,
            Country = business.Country,
            ImageUrls = business.ImageUrls,
            AverageRating = business.AverageRating,
            TotalReviews = business.TotalReviews,
            IsFeatured = business.IsFeatured
        };
    }

    public async Task<IEnumerable<BusinessDto>>
    GetBusinessesByOwnerAsync(string ownerId)
    {
      var businesses =
        await _businessRepository.GetByOwnerAsync(ownerId);

      return businesses.Select(MapToDto);
    }
}