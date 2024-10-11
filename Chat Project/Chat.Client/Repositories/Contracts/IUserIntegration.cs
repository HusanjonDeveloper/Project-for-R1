namespace Chat.Client.Repositories.Contracts;

public interface IUserIntegration
{
    Task<Tuple<HttpStatusCode, string>> Login(LoginModel model);
    Task<Tuple<HttpStatusCode, string>> Register(RegisterModel model);

    Task<Tuple<HttpStatusCode, object>> GetAllUsers();
    Task<Tuple<HttpStatusCode, object?>> GetProfile(byte age);
    
    Task<Tuple<HttpStatusCode, object?>> UpdateAge(byte sge);
    
    Task<Tuple<HttpStatusCode, object?>> UpdateBio(string bio);
}