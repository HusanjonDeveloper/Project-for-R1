using System.Net;

namespace Chat.Client.Repositories.Contracts;

public interface IChatIntegration
{
    Task<Tuple<HttpStatusCode, object>> GetUserChats();
    
    Task<Tuple<HttpStatusCode, object>> GetUserChat(Guid toUserId);
    
    Task<Tuple<HttpStatusCode, object>> GetChatMessage(Guid  chatId);
    
    Task<Tuple<HttpStatusCode, object>> SendTextMessage(Guid  chatId, string text);
}