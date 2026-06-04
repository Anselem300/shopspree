using BCrypt.Net;
using ShopSpree.Core.DTOs;
using ShopSpree.Core.Interfaces;
using ShopSpree.Core.Models;
using ShopSpree.Infrastructure.Repositories;

namespace ShopSpree.Infrastructure.Services;

public class AuthService : IUserService
{
    private readonly IUserRepository _userRepository;

    public AuthService(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> RegisterAsync(
        RegisterDto registerDto)
    {
        var existingUser =
            await _userRepository
                .GetByEmailAsync(registerDto.Email);

        if (existingUser is not null)
        {
            return false;
        }

        var user = new ApplicationUser
        {
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            Email = registerDto.Email,
            PasswordHash =
                BCrypt.Net.BCrypt.HashPassword(
                    registerDto.Password)
        };

        await _userRepository.CreateAsync(user);

        return true;
    }

    public async Task<ApplicationUser?> LoginAsync(
        LoginDto loginDto)
    {
        var user =
            await _userRepository
                .GetByEmailAsync(loginDto.Email);

        if (user is null)
        {
            return null;
        }

        bool validPassword =
            BCrypt.Net.BCrypt.Verify(
                loginDto.Password,
                user.PasswordHash);

        return validPassword
            ? user
            : null;
    }

    public async Task<ApplicationUser?> GetUserByIdAsync(
        string userId)
    {
        return await _userRepository
            .GetByIdAsync(userId);
    }

    public async Task<ApplicationUser?> GetUserByEmailAsync(
        string email)
    {
        return await _userRepository
            .GetByEmailAsync(email);
    }

    public async Task UpdateProfileAsync(UpdateUserDto dto)
{
    Console.WriteLine($"DTO Image URL: {dto.ProfileImageUrl}");

    var user = await _userRepository.GetByIdAsync(dto.Id);

    if (user is null)
        throw new Exception("User not found");

    user.FirstName = dto.FirstName;
    user.LastName = dto.LastName;
    user.Email = dto.Email;
    user.ProfileImageUrl = dto.ProfileImageUrl;

    Console.WriteLine($"User Image URL: {user.ProfileImageUrl}");

    await _userRepository.UpdateAsync(user);
}

public async Task DeleteUserAsync(string userId)
{
    await _userRepository.DeleteAsync(userId);
}
}