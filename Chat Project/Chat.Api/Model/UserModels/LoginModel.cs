using Microsoft.Build.Framework;

namespace Chat.Api.Model.UserModels;

public class LoginModel
{
    [Required]
    
    public  string UserName  { get; set; }
    
    [Required]
    public string Password { get; set; }
}