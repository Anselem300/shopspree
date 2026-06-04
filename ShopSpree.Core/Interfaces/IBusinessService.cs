using ShopSpree.Core.DTOs;
using ShopSpree.Core.Models;

namespace ShopSpree.Core.Interfaces;

public interface IBusinessService
{
    Task<List<Business>> GetAllBusinessesAsync();

    Task<Business?> GetBusinessByIdAsync(string id);

    Task<List<Business>> GetBusinessesByOwnerAsync(string ownerId);

    Task<List<Business>> SearchBusinessesAsync(
        string? search,
        string? category,
        string? city);

    Task CreateBusinessAsync(
        CreateBusinessDto dto,
        string ownerId,
        string imageUrl);

    Task UpdateBusinessAsync(UpdateBusinessDto dto);

    Task DeleteBusinessAsync(string id);
}