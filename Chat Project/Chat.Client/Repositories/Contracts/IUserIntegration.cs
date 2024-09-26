using System.Net;
using Chat.Client.Models;

namespace Chat.Client.Repositories.Contracts;

public interface IUserIntegration
{
    Task<Tuple<HttpStatusCode, string>> Login(LoginModel model);
    Task<Tuple<HttpStatusCode, string>> Register(RegisterModel model);

    Task<Tuple<HttpStatusCode, object>> GetAllUsers();
}