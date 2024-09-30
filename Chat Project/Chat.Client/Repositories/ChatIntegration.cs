using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Chat.Client.Models;
using Chat.Client.Repositories.Contracts;
using Chat.Client.Services;

namespace Chat.Client.Repositories;

public class ChatIntegration(HttpClient httpClient, StorageService storageService) : IChatIntegration
{
      private readonly HttpClient _httpClient = httpClient;
      private readonly StorageService _storageService = storageService;

      public async Task<Tuple<HttpStatusCode, object>> GetUserChats()
      {
          await AddTokenToHeader();

          string url = "api/users/user_id/chats";
          
          var result = await _httpClient.GetAsync(url);
          
          var statusCode = result.StatusCode;

          object response;
          
          if (statusCode != HttpStatusCode.OK)
          {
              response = (await result.Content.ReadFromJsonAsync<List<ChatDto>>())!;
          }
          else
          {
              response = (await result.Content.ReadFromJsonAsync<string>())!;
          }
          
          return new (statusCode, response);
          
      }

      public async Task<Tuple<HttpStatusCode, object>> GetUserChat(Guid toUserId)
      {
          await AddTokenToHeader();

          string url = "api/users/user_id/chats";
          
          var result = await _httpClient.PostAsJsonAsync(url,toUserId);
          
          var statusCode = result.StatusCode;

          object response;
          
          if (statusCode != HttpStatusCode.OK)
          {
              response = (await result.Content.ReadFromJsonAsync<ChatDto>())!;
          }
          else
          {
              response = (await result.Content.ReadFromJsonAsync<string>())!;
          }
          
          return new (statusCode, response);

      }

      public async Task<Tuple<HttpStatusCode, object>> GetChatMessage(Guid chatId)
      {
        
          await AddTokenToHeader();

          string url = $"api/users/user_id/chats/{chatId}/message";
          
          var result = await _httpClient.GetAsync(url);
          
          var statusCode = result.StatusCode;

          object response;
          
          if (statusCode != HttpStatusCode.OK)
          {
              response = (await result.Content.ReadFromJsonAsync<List<MessageDto>>())!;
          }
          else
          {
              response = (await result.Content.ReadFromJsonAsync<string>())!;
          }
          
          return new (statusCode, response);
      }

      public async Task<Tuple<HttpStatusCode, object>> SendTextMessage(Guid chatId, string text)
      {
          await AddTokenToHeader();

          string url = "api/users/user_id/chats/{chatId}/message/send-text-message}";

          var model = new TextModel()
          {
              Text = text
          };
          
          var result = await _httpClient.PostAsJsonAsync(url,model);
          
          var statusCode = result.StatusCode;

          object response;
          
          if (statusCode != HttpStatusCode.OK)
          {
              response = (await result.Content.ReadFromJsonAsync<MessageDto>())!;
          }
          else
          {
              response = (await result.Content.ReadFromJsonAsync<string>())!;
          }
          
          return new (statusCode, response);
      }

      private async Task AddTokenToHeader()
    {
        
        string? token = await _storageService.GetToken();

        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }
}