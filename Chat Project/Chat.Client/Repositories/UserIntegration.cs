using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Chat.Client.Models;
using Chat.Client.Repositories.Contracts;

namespace Chat.Client.Repositories;

public class UserIntegration(HttpClient httpClient, ILocalStorageService localStorageService) : IUserIntegration
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILocalStorageService _localStorageService = localStorageService;

    public async Task<Tuple<HttpStatusCode, string>> Login(LoginModel model)
    {
        string url = "api/Users/login";


        var result = await _httpClient.PostAsJsonAsync(url, model);

        var statusCode = result.StatusCode;

        var response = await result.Content.ReadAsStringAsync();

        return new(statusCode, response);
    }

    public async Task<Tuple<HttpStatusCode, string>> Register(RegisterModel model)
    {
        string url = "api/Users/register";

        var result = await _httpClient.
            PostAsJsonAsync(url, model);

        var statusCode = result.StatusCode;

        var response = await result.Content.ReadAsStringAsync();


        return new(statusCode, response);
    }

    public async Task<Tuple<HttpStatusCode, object>> GetAllUsers()
    {
        string url = "api/users";

        var token = await _localStorageService.
            GetItemAsStringAsync("token");

        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer",token);
        }

        var result = await _httpClient.GetAsync(url);

        var statusCode = result.StatusCode;

        if (statusCode == HttpStatusCode.OK)
        {
            var users = await result.Content.ReadFromJsonAsync<List<UserDto>>();
            return new (statusCode, users!);
        }

        else if (statusCode == HttpStatusCode.BadRequest)
        {
            var response = await result.Content.ReadAsStringAsync();
            return new(statusCode, response);
        }

        else if (statusCode == HttpStatusCode.Unauthorized)
            return new(statusCode, "Unauthorized");

        return new(statusCode, "Something wrong");
    }
}