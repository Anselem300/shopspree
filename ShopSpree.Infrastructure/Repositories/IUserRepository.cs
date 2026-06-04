using ShopSpree.Core.Models;

namespace ShopSpree.Infrastructure.Repositories;

public interface IUserRepository
{
    Task<ApplicationUser?> GetByIdAsync(string id);

    Task<ApplicationUser?> GetByEmailAsync(string email);

    Task CreateAsync(ApplicationUser user);

    Task UpdateAsync(ApplicationUser user);

    Task DeleteAsync(string id);
}