namespace Chat.Api.Entities;

public class UserChat
{
    public  Guid Id { get; set; }
    
    public  Guid UserChatId { get; set; } // nuni qilishdan maqsad one-tomeny
    
    public  User? User { get; set; }

    public  Guid ChatId { get; set; }
    
    public  Chat? Chat { get; set; }
}