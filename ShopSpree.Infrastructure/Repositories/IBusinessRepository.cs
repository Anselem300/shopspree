using ShopSpree.Core.Models;

namespace ShopSpree.Infrastructure.Repositories;

public interface IBusinessRepository
{
    Task<List<Business>> GetAllAsync();

    Task<Business?> GetByIdAsync(string id);

    Task<List<Business>> GetByOwnerAsync(string ownerId);

    Task CreateAsync(Business business);

    Task UpdateAsync(Business business);

    Task DeleteAsync(string id);
}