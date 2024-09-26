using Chat.Api.Manager;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;

[Route("api/users/{userId:guid}/[controller]")]
[ApiController]

public class ChatsController(ChatManager chatManager) : Controller
{

    private readonly ChatManager _chatManager = chatManager;

    [HttpGet]
    public async Task<IActionResult> GetUserChats(Guid userId)
    {
        var chats = await _chatManager.GetAllUserChats(userId);
        return Ok(chats);
    }

    [HttpPost]
    public async Task<IActionResult> AddOrEnterChat(Guid userId,[FromBody] Guid toUserId)
    {
        var chat = await _chatManager.AddOrEnterChat(userId, toUserId);
        return Ok(chat);
    }
}