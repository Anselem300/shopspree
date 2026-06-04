using ShopSpree.Core.DTOs;
using ShopSpree.Core.Interfaces;
using ShopSpree.Core.Models;
using ShopSpree.Infrastructure.Repositories;

namespace ShopSpree.Infrastructure.Services;

public class BusinessService : IBusinessService
{
    private readonly IBusinessRepository _repo;

    public BusinessService(IBusinessRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Business>> GetAllBusinessesAsync()
        => await _repo.GetAllAsync();

    public async Task<Business?> GetBusinessByIdAsync(string id)
        => await _repo.GetByIdAsync(id);

    public async Task<List<Business>> GetBusinessesByOwnerAsync(string ownerId)
        => await _repo.GetByOwnerAsync(ownerId);

    public async Task<List<Business>> SearchBusinessesAsync(
        string? search,
        string? category,
        string? city)
    {
        var all = await _repo.GetAllAsync();

        return all.Where(b =>
            (string.IsNullOrEmpty(search) ||
             b.Name.Contains(search, StringComparison.OrdinalIgnoreCase)) &&

            (string.IsNullOrEmpty(category) || b.Category == category) &&

            (string.IsNullOrEmpty(city) || b.City == city)
        ).ToList();
    }

    public async Task CreateBusinessAsync(
        CreateBusinessDto dto,
        string ownerId,
        string imageUrl)
    {
        var business = new Business
        {
            OwnerId = ownerId,
            Name = dto.Name,
            Description = dto.Description,
            Category = dto.Category,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Address = dto.Address,
            City = dto.City,
            ImageUrl = imageUrl
        };

        await _repo.CreateAsync(business);
    }

    public async Task UpdateBusinessAsync(UpdateBusinessDto dto)
{
    Console.WriteLine($"Updating Business: {dto.Id}");

    var business =
        await _repo.GetByIdAsync(dto.Id);

    Console.WriteLine(
        $"Business Found: {business?.Name}");

    if (business is null)
        return;

    business.Name = dto.Name;
    business.Description = dto.Description;
    business.Category = dto.Category;
    business.PhoneNumber = dto.PhoneNumber;
    business.Email = dto.Email;
    business.Address = dto.Address;
    business.City = dto.City;
    business.ImageUrl = dto.ImageUrl;

    Console.WriteLine(
        $"New Name: {business.Name}");

    await _repo.UpdateAsync(business);

    Console.WriteLine("UpdateAsync completed");
}

    public async Task DeleteBusinessAsync(string id)
        => await _repo.DeleteAsync(id);
}