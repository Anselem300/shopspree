using System.Security.Claims;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using ShopSpree.Application.DTOs;
using ShopSpree.Application.Interfaces;
using ShopSpree.Domain.Entities;
using ShopSpree.Shared.Auth;

namespace ShopSpree.Infrastructure.Authentication;

public class CustomAuthenticationService : IAuthenticateService
{
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CustomAuthenticationService(
        IUserRepository userRepository,
        IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<UserDto?> LoginAsync(LoginRequest request)
    {
      var user =
        await _userRepository.GetByEmailAsync(request.Email);

      if (user is null)
        return null;

      var passwordValid =
        BCrypt.Net.BCrypt.Verify(
            request.Password,
            user.PasswordHash);

      if (!passwordValid)
        return null;

      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
        new Claim(ClaimTypes.Email, user.Email)
      };

      var identity = new ClaimsIdentity(
        claims,
        CookieAuthenticationDefaults.AuthenticationScheme);

      var principal = new ClaimsPrincipal(identity);

      await _httpContextAccessor.HttpContext!
        .SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal);

      return MapToDto(user);
   }

    public async Task LogoutAsync()
    {
        await _httpContextAccessor.HttpContext!
            .SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public async Task<bool> RegisterAsync(RegisterRequest request)
    {
        var existingUser =
            await _userRepository.GetByEmailAsync(request.Email);

        if (existingUser != null)
            return false;

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            PasswordHash =
                BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        await _userRepository.CreateAsync(user);

        return true;
    }

    public async Task<UserDto?> GetCurrentUserAsync()
    {
        var email =
            _httpContextAccessor.HttpContext?
            .User?
            .FindFirst(ClaimTypes.Email)?
            .Value;

        if (string.IsNullOrWhiteSpace(email))
            return null;

        var user =
            await _userRepository.GetByEmailAsync(email);

        return user is null
            ? null
            : MapToDto(user);
    }

    private static UserDto MapToDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            ProfileImageUrl = user.ProfileImageUrl,
            IsBusinessOwner = user.IsBusinessOwner
        };
    }
}