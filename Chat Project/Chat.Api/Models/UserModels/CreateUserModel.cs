using System.ComponentModel.DataAnnotations;

namespace Chat.Api.Models.UserModels;

public class CreateUserModel
{
    public string FirstName { get; set; }

    public string? LastName { get; set; }

    public string Username { get; set; }
    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    
    public string? Gender { get; set; }
}