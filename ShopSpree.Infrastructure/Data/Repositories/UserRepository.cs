using MongoDB.Driver;
using ShopSpree.Application.Interfaces;
using ShopSpree.Domain.Entities;

namespace ShopSpree.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MongoContext _context;

    public UserRepository(MongoContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(User user)
    {
        await _context.Users.InsertOneAsync(user);
    }

    public async Task DeleteAsync(string id)
    {
        await _context.Users.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users
            .Find(_ => true)
            .ToListAsync();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .Find(x => x.Email == email)
            .FirstOrDefaultAsync();
    }

    public async Task<User?> GetByIdAsync(string id)
    {
        return await _context.Users
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync();
    }
}