using ShopSpree.Domain.Entities;

namespace ShopSpree.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(string id);
    Task<User?> GetByEmailAsync(string email);
    Task<List<User>> GetAllAsync();
    Task CreateAsync(User user);
    Task DeleteAsync(string id);
}