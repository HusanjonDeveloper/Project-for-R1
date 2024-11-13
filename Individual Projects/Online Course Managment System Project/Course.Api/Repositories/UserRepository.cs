using Course.Data.Context;
using Course.Data.Entitiyes;

namespace Course.Data.Repositories;

public class UserRepository : IUserRepository
{

    private readonly CourseDbContext _context;

    public UserRepository(CourseDbContext context)
    {
        _context = context;
    }

    public Task CheckUserExist(string phoneNumber)
    {
        var user  =  _context.Users.FirstOrDefault(x => x.PhoneNumber == phoneNumber)!;
        if(user != null)
            throw new Exception($"User {phoneNumber} is already registered");
        return Task.CompletedTask;
    }

    public async Task Create(User model)
    {
        await _context.Users.AddAsync(model);
        await _context.SaveChangesAsync();
    }
}