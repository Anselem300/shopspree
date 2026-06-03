using ShopSpree.Application.DTOs;
using ShopSpree.Shared.Auth;

namespace ShopSpree.Application.Interfaces;

public interface IAuthenticateService
{
    Task<UserDto?> LoginAsync(LoginRequest request);

    Task LogoutAsync();

    Task<bool> RegisterAsync(RegisterRequest request);

    Task<UserDto?> GetCurrentUserAsync();
}