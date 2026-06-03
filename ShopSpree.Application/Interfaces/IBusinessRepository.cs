using ShopSpree.Domain.Entities;

namespace ShopSpree.Application.Interfaces;

public interface IBusinessRepository
{
    Task<List<Business>> GetAllAsync();
    Task<Business?> GetByIdAsync(string id);
    Task<List<Business>> SearchAsync(string keyword);
    Task<List<Business>> GetByCategoryAsync(string categoryId);
    Task<List<Business>> GetByLocationAsync(string city);
    Task<List<Business>> GetByOwnerAsync(string ownerId);
    Task CreateAsync(Business business);
    Task UpdateAsync(Business business);
    
    Task DeleteAsync(string id);
}