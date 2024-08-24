namespace Chat.Api.Entities;

public class Chat
{
    public  Guid Id  { get; set; }
    
    public  string Name { get; set; }
    
    public  List<User> Users { get; set; }
}