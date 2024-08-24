namespace Chat.Api.Entities;

public class User
{
    public  Guid Id { get; set; }
    
    public  string Name { get; set; }
    
    public  List<Chat> Chats { get; set; }
}