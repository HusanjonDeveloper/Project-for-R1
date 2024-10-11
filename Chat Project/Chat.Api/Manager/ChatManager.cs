namespace Chat.Api.Manager;


public class ChatManager(IUnitOfWork unitOfWork)
{
     private readonly IUnitOfWork _unitOfWork = unitOfWork;
     
       
     // for Admin 
     public async Task<List<ChatDto>> GetAllChats()
     {
          var chats = await _unitOfWork.ChatRepositoriy.GetAllChats();

          return chats.ParseToDtos();
     }


     public async Task<List<ChatDto>> GetAllUserChats(Guid userId)
     {
          var chats = await _unitOfWork.ChatRepositoriy.GetAllUserChats(userId); 
        
          return chats.ParseToDtos();   
     }

     public async Task<ChatDto> GetUserChatById(Guid userId, Guid chatId)
     {
          var chat = await   _unitOfWork.ChatRepositoriy.GetUserChatById(userId, chatId);

          return chat.ParseToDto();

     }


     public async Task<ChatDto> AddOrEnterChat(Guid fromUserId, Guid toUserId)
     {
          var (check, chat) = 
               await _unitOfWork.ChatRepositoriy.CheckChatExist(fromUserId, toUserId);

          if (check)
             return  chat?.ParseToDto()!;
          
          var fromUser = await _unitOfWork.UserRepository.GetUserById(fromUserId);
          var  toUser = await _unitOfWork.UserRepository.GetUserById(toUserId);

          List<string> names = new()
          {
               StaticHelper.GetFullName(fromUser.FirstName, fromUser.LastName),
               StaticHelper.GetFullName(toUser.FirstName, toUser.LastName)
          };

          chat = new()
          {
               ChatNames = names,
          };

          await _unitOfWork.ChatRepositoriy.AddChat  (chat);
           
          var fromUseChat = new UserChat()
          {
               UserId =  fromUserId,
               ToUserId = toUserId,
               ChatId = chat.Id,
          };

          await _unitOfWork.UserChatRepository.AddUserChat(fromUseChat);
          
          var toUseChat = new UserChat()
          {
               UserId = toUserId,
               ChatId = chat.Id,
               ToUserId = fromUserId
          };
          
          await _unitOfWork.UserChatRepository.AddUserChat(toUseChat);
          
          return chat.ParseToDto(); 
     }

     public async Task<string> DeleteChat(Guid userId, Guid chatId)
     {
          var user = await _unitOfWork.UserRepository.GetUserById(userId);

          var chat = await _unitOfWork.ChatRepositoriy.GetUserChatById(userId, chatId);

          await _unitOfWork.ChatRepositoriy.DeleteChat(chat);
          
          return "Deleted Successfully";
     }
      
      
}