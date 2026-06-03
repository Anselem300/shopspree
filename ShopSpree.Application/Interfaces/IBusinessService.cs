using ShopSpree.Application.DTOs;
using ShopSpree.Shared.Business;

namespace ShopSpree.Application.Interfaces;

public interface IBusinessService
{
    Task<IEnumerable<BusinessDto>> GetAllAsync();

    Task<BusinessDto?> GetByIdAsync(string id);

    Task<IEnumerable<BusinessDto>> SearchAsync(string keyword);

    Task<IEnumerable<BusinessDto>> FilterByCategoryAsync(string categoryId);

    Task<IEnumerable<BusinessDto>> FilterByLocationAsync(string city);

    Task<bool> CreateAsync(CreateBusinessRequest request, string ownerId);

    Task<bool> UpdateAsync(UpdateBusinessRequest request);

    Task<bool> DeleteAsync(string id);

    Task<IEnumerable<BusinessDto>> GetBusinessesByOwnerAsync(string ownerId);
}