namespace Chat.Api.Repositories;

public interface IMessageRepository
{
    // admin
    Task<List<Message>> GetMessages();
    
    // user
    Task<List<Message>> GetchatMessages(Guid chatId);
    
    // admin 
    Task<Message> GetMessageById(int id);
    
    // user
    Task<Message> GetChatMessageById(Guid chatId, int messageId);
    Task AddMessage(Message message);
}