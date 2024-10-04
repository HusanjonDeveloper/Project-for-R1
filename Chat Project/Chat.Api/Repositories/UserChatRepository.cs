using Chat.Api.Context;
using Chat.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Api.Repositories;

public class UserChatRepository(ChatDbContext context)  : IUserChatRepository
{
    private readonly ChatDbContext _context = context;

    public async Task AddUserChat(UserChat userChat)
    {
        await _context.UserChats.AddAsync(userChat);
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserChat(UserChat userChat)
    {
         _context.UserChats.Remove(userChat);
        
        await _context.SaveChangesAsync();
    }

    public async Task GetUserChat(Guid userId, Guid chatId)
    {
       var userChat = await _context.UserChats.
           SingleOrDefaultAsync(x => x.UserId == userId && x.ChatId == chatId);

       if (userChat is null)
           throw new Exception("Not Found Chat");

    }
}