using Chat.Api.Context;
using Chat.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Api.Repositories;

public class UserRepository(ChatDbContext context) : IUserRepository
{
    private readonly ChatDbContext _context = context;

    public async Task<List<User>> GetAllUsers()
    {
        var users = await _context.Users.AsNoTracking().ToListAsync();
        return users;
    }

    public async Task<User> GetUserById(Guid id)
    {
        var users = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        return users;
    }

    public async Task<User>? GetUserByUsername(string username)
    {
        throw new NotImplementedException();
    }

    public async Task AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteUser(User user)
    {
        throw new NotImplementedException();
    }
}