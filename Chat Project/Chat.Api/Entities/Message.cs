using Microsoft.Build.Framework;

namespace Chat.Api.Entities;

public class Message
{
    public  int Id { get; set; }

    public  string? Text { get; set; }

    public   Guid FromUsrId  { get; set; }
    
    [Required]
    public  string FromUserName  { get; set; }

    public  Guid ChatId { get; set; }

    public  Chat? Chat { get; set; }

    public  int ContentId { get; set; }

    public  Content? Content { get; set; }

    public  bool IsEdited { get; set; }
    
    public DateTime SendAt => DateTime.Now;
    
    public  DateTime? EditedAt { get; set; }
}