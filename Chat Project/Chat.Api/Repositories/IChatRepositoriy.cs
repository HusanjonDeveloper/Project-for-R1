namespace Chat.Api.Repositories;

public interface IChatRepositoriy
{
    Task<List<Entities.Chat>> GetAllChats();
    Task<List<Entities.Chat>> GetAllUserChats(Guid userId);
    Task<Entities.Chat> GetUserChatById(Guid userId,Guid chatId);
    Task<bool> CheckChatExist(Guid fromUserId, Guid toUserId);
    Task AddUserChat(Entities.Chat chat);
    Task UpdateChat(Entities.Chat chat);
    Task DeleteChat(Entities.Chat chat); 

}