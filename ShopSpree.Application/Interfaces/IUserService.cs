using ShopSpree.Application.DTOs;

namespace ShopSpree.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();

    Task<UserDto?> GetByIdAsync(string id);

    Task<UserDto?> GetByEmailAsync(string email);

    Task<bool> DeleteAsync(string id);
}