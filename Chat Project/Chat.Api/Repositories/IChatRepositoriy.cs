namespace Chat.Api.Repositories;

public interface IChatRepositoriy
{
    Task<List<Entities.Chat>> GetAllChats();
    Task<Entities.Chat> GetAllUserChats(Guid userId);
    Task<Entities.Chat> GetUserChatById(Guid userId,Guid chatId);
    Task AddOrEnterChat(Guid userId);
    Task UpdateChat(Entities.Chat chat);
    Task DeleteChat(Entities.Chat chat);

}