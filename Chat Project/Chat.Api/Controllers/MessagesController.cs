namespace Chat.Api.Controllers;

[Route("api/users/user_id/chats/{chatId}[controller]")]
[ApiController]

public class MessagesController(MessageManager messageManager, UserHelper userHelper) : ControllerBase
{
   private readonly MessageManager _messageManager = messageManager;

   private readonly UserHelper _userHelper = userHelper;

   // Admin 
   [Authorize(Roles = "admin")]
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

   // user
   [Authorize(Roles = "user")]
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

   [Authorize(Roles = "admin,user")]
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

   [Authorize(Roles = "admin,user")]
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

   [Authorize(Roles = "admin,user")]
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

   [Authorize(Roles = "admin,user")]
   [HttpPost("send-file-message")]
   public async Task<IActionResult> SendFileMessage(Guid chatId, FileModel model)
   {
      try
      {
         var userId = _userHelper.GetUserId();

         var result = await _messageManager.SendFileMessage(userId, chatId, model);
         return Ok(result);
      }
      catch (Exception e)
      {
         return BadRequest(e.Message);
      }
   }
   
