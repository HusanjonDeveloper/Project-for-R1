using Microsoft.Build.Framework;

namespace Chat.Api.Entities;

public class User
{
    public  Guid Id { get; set; }
    
    public  byte? Age { get; set; }
    
    [Required]
    public  string FirstName { get; set; }

    public  string? LastName { get; set; }
    [Required]
    
    public  string UserName  { get; set; }
    
    [Required]
    public string OAsswordHash  { get; set; }
    
    [Required] 
    public  string Gender  { get; set; }

    public  string? Bio { get; set; }

    public  string? PhotoUrl { get; set; }
    public  DateTime  CreatedDateTime => DateTime.UtcNow;

    public  List<UserChat>? UserChats { get; set; }
    
    
}