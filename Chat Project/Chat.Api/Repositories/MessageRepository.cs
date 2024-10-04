using Chat.Api.Context;
using Chat.Api.Entities;
using Chat.Api.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Chat.Api.Repositories;

public class MessageRepository(ChatDbContext dbContext) : IMessageRepository
{
    
    private readonly ChatDbContext _dbContext = dbContext;


    public async Task<List<Message>> GetMessages()
    {
        var message = await _dbContext.Messages
            .Include(x => x.Content).ToListAsync();
        
        return message;
    }

    public async Task<List<Message>> GetchatMessages(Guid chatId)
    {
        var message = await _dbContext.Messages
            .Include(x => x.Content).
            Where(x => x.ChatId == chatId).ToListAsync();
       
        return message;
    }

    public async Task<Message> GetMessageById(int id)
    {
        var message = await _dbContext.Messages.SingleOrDefaultAsync(x => x.Id == id);

        if (message == null)
            throw new GetMessageNotfoundException();

        return message;
    }

    public async Task<Message> GetChatMessageById(Guid chatId, int messageId)
    {
        var message = await _dbContext.Messages
            .SingleOrDefaultAsync(x => x.Id == messageId && x.ChatId == chatId);

        if (message == null)
            throw new GetMessageNotfoundException();

        return message;
    }

    public async Task AddMessage(Message message)
    {
      _dbContext.Messages.Add(message);
      _dbContext.SaveChanges();
    }
}