using ShopSpree.Core.DTOs;
using ShopSpree.Core.Models;

namespace ShopSpree.Core.Interfaces;

public interface IUserService
{
    Task<bool> RegisterAsync(RegisterDto registerDto);

    Task<ApplicationUser?> LoginAsync(LoginDto loginDto);

    Task<ApplicationUser?> GetUserByIdAsync(string userId);

    Task<ApplicationUser?> GetUserByEmailAsync(string email);

    Task UpdateProfileAsync(UpdateUserDto dto);
    Task DeleteUserAsync(string userId);
}