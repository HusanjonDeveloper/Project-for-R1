namespace Chat.Api.Model;

public class FileModel
{
    [Required] 
    public  IFormFile File { get; set; }
}