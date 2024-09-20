using Chat.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Chat.Api.Repositories;

public class ChatRepositoriy(ChatDbContext context) : IChatRepositoriy
{
    private readonly ChatDbContext _context = context;


    public async Task<List<Entities.Chat>> GetAllChats()
    {
        var chats = await _context.Chats.AsNoTracking().ToListAsync();
        return chats;
    }

    public async Task<List<Entities.Chat>> GetAllUserChats(Guid userId)
    {
        var userChats =
            await _context.UserChats.
                Where(x => x.UserId == userId).ToListAsync();

        List<Entities.Chat> sortedChats = new();
        var check = userChats == null || userChats.Count == 0;
        if (check)
            return sortedChats;

        foreach (var chat in userChats)
        {
            var sortedChat = await
                _context.Chats.SingleAsync(x => x.Id == chat.ChatId);
                 sortedChats.Add(sortedChat);
        }
        return sortedChats;
    }

    public Task<Entities.Chat> GetUserChatById(Guid userId, Guid chatId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckChatExist(Guid fromUserId, Guid toUserId)
    {
        throw new NotImplementedException();
    }

    public Task AddOrEnterChat(Entities.Chat chat)
    {
        throw new NotImplementedException();
    }

    public Task UpdateChat(Entities.Chat chat)
    {
        throw new NotImplementedException();
    }

    public Task DeleteChat(Entities.Chat chat)
    {
        throw new NotImplementedException();
    }
}