using MongoDB.Driver;
using ShopSpree.Core.Models;
using ShopSpree.Infrastructure.Data;

namespace ShopSpree.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MongoDbContext _context;

    public UserRepository(MongoDbContext context)
    {
        _context = context;
    }

    public async Task<ApplicationUser?> GetByIdAsync(string id)
    {
        return await _context.Users
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<ApplicationUser?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .Find(x => x.Email == email)
            .FirstOrDefaultAsync();
    }

    public async Task CreateAsync(ApplicationUser user)
    {
        await _context.Users.InsertOneAsync(user);
    }

    public async Task UpdateAsync(ApplicationUser user)
    {
        await _context.Users.ReplaceOneAsync(
            x => x.Id == user.Id,
            user);
    }

    public async Task DeleteAsync(string id)
    {
        await _context.Users.DeleteOneAsync(
            x => x.Id == id);
    }
    
}