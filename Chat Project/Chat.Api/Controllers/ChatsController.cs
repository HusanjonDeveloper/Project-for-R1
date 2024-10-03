using Chat.Api.Helpers;
using Chat.Api.Manager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;

[Route("api/users/user_id/[controller]")]
[ApiController]

public class ChatsController(ChatManager chatManager, UserHelper userHelper) : Controller
{

    private readonly ChatManager _chatManager = chatManager;

    private readonly UserHelper userHelper = userHelper;
    
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetUserChats()
    {
        var chats = await _chatManager.GetAllUserChats(userHelper.GetUserId());
        return Ok(chats);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddOrEnterChat([FromBody] Guid toUserId)
    {
        var chat = await _chatManager.AddOrEnterChat(userHelper.GetUserId(), toUserId);
        return Ok(chat);
    }

    [Authorize]
    [HttpDelete("{chatId:guid}")]
    public async Task<IActionResult> DeleteChat(Guid chatId)
    {
        try
        {
            var result = await _chatManager.DeleteChat(userHelper.GetUserId(), chatId);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}