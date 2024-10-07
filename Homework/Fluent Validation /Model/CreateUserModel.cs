namespace Fluent_Validation.Model;

public class CreateUserModel
{
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }
        
        public string Gender { get; set; }
        
}