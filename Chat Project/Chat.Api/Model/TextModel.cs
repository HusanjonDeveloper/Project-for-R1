using Microsoft.Build.Framework;

namespace Chat.Api.Model;

public class TextModel
{
    [Required] 
    public  string Text { get; set; }
}