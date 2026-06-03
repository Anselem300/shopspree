using MongoDB.Driver;
using ShopSpree.Application.Interfaces;
using ShopSpree.Domain.Entities;

namespace ShopSpree.Infrastructure.Data.Repositories;

public class BusinessRepository : IBusinessRepository
{
    private readonly MongoContext _context;

    public BusinessRepository(MongoContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Business business)
    {
        await _context.Businesses.InsertOneAsync(business);
    }

    public async Task DeleteAsync(string id)
    {
        await _context.Businesses.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<Business>> GetAllAsync()
    {
        return await _context.Businesses
            .Find(_ => true)
            .ToListAsync();
    }

    public async Task<Business?> GetByIdAsync(string id)
    {
        return await _context.Businesses
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Business>> GetByCategoryAsync(
        string categoryId)
    {
        return await _context.Businesses
            .Find(x => x.CategoryId == categoryId)
            .ToListAsync();
    }

    public async Task<List<Business>> GetByLocationAsync(
        string city)
    {
        return await _context.Businesses
            .Find(x => x.City == city)
            .ToListAsync();
    }

    public async Task<List<Business>> SearchAsync(
        string keyword)
    {
        return await _context.Businesses
            .Find(x =>
                x.BusinessName.Contains(keyword) ||
                x.Description.Contains(keyword))
            .ToListAsync();
    }

    public async Task UpdateAsync(Business business)
    {
        await _context.Businesses.ReplaceOneAsync(
            x => x.Id == business.Id,
            business);
    }

    public async Task<List<Business>> GetByOwnerAsync(string ownerId)
    {
      return await _context.Businesses
        .Find(x => x.OwnerId == ownerId)
        .ToListAsync();
    }
}