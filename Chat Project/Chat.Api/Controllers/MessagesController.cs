using Chat.Api.Helpers;
using Chat.Api.Manager;
using Chat.Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;

[Authorize]
[Route("api/users/user_id/chats/{chatId}[controller]")]
[ApiController]

public class MessagesController(MessageManager messageManager, UserHelper userHelper) : ControllerBase
{
   private readonly MessageManager _messageManager = messageManager;

   private readonly UserHelper _userHelper = userHelper;

   // Admin 
   [HttpGet("/api/messages")]
   public async Task<IActionResult> GetllMessages()
   {
      try
      {
         var messages = await _messageManager.GetMessage();
      
         return Ok(messages);
      }
      catch (Exception e)
      {
         return BadRequest(e.Message);
      }
   }

   // Admin
   [HttpGet ("/api/messages/{messageId:int}")]
   public async Task<IActionResult> GetMessageById(int messageId)
   {
      try
      {
         var message = await _messageManager.GetMessageById(messageId);
         
         return Ok(message);
      }
      catch (Exception e)
      {
         return BadRequest(e.Message);
      }
   }

   [HttpGet]
   public async Task<IActionResult> GetChatMessages(Guid chatId)
   {
      try
      {
         var messages = await _messageManager.GetChatMessage(chatId);
         return Ok(messages);
      }
      catch (Exception e)
      {
         return BadRequest(e.Message);
      }
   }

   [HttpGet("{messageId:int}")]

   public async Task<IActionResult> GetChatMessageById(Guid chatId, int messageId)
   {
      try
      {
         var message = await _messageManager.GetChatMessageById(chatId, messageId);
         return Ok(message);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
   }

   [HttpPost("send-text-message")]
   public async Task<IActionResult> SendTextMessage(Guid chatId, TextModel model)
   {
      try
      {
         var userId = _userHelper.GetUserId();
          var message  = await _messageManager.SendTextMessage(userId, chatId, model);
          return Ok(message);
      }
      catch (Exception e)
      {
         return BadRequest(e.Message);
      }
   }
   
}