using Microsoft.Build.Framework;

namespace Chat.Api.Model.UserModels;

public class UpdateUsernameModel
{
    [Required]
    public string Username { get; set; }
}