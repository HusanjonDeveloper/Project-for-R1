namespace Chat.Api.Manager;


public class MessageManager(IUnitOfWork unitOfWork, IHostEnvironment hostEnvironment)
{
    // 1 GetMessage
    // 2 GetChatMessage
    // 3 GetMessageById
    // 4 GetChatMessageById
    // 5 SendMessage
    
    private  readonly IUnitOfWork _unitOfWork = unitOfWork;

    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    public async Task<List<MessageDto>> GetMessage()
    {
        var message = await _unitOfWork.MessageRepository.GetMessages();
       
        return message.ParseToDtos();
    }


    public async Task<List<MessageDto>> GetChatMessage(Guid chatId)
    {
        
        var message = await _unitOfWork.MessageRepository
            .GetchatMessages(chatId);
        
        return message.ParseToDtos();
    }


    public async Task<MessageDto> GetMessageById(int messageId)
    {
        var message = await _unitOfWork.MessageRepository.GetMessageById(messageId);
        
        return message.ParseToDto();
    }

    public async Task<MessageDto> GetChatMessageById(Guid chatId, int messageId)
    {
        var message = await _unitOfWork.MessageRepository.GetChatMessageById(chatId, messageId);
        
        return message.ParseToDto();
    }

    public async Task<MessageDto> SendTextMessage(Guid userId,Guid chatId, TextModel model)
    {
       await  CheckingUserInChat(userId:userId, chatId:chatId);
       
        var user = await _unitOfWork.UserRepository.GetUserById(userId);
        
      
        var message = new  Entities.Message()
        {
            Text = model.Text,
            FromUsrId = userId,
            FromUserName = user.UserName,
            ChatId = chatId
        };

        await _unitOfWork.MessageRepository.AddMessage(message);

        return message.ParseToDto();
    }
    
    

    public async Task<MessageDto> SendFileMessage(Guid userId, Guid chatId, FileModel model)
    {
        var user = await _unitOfWork.UserRepository.GetUserById(userId);
        
        await CheckingUserInChat(userId: userId, chatId: chatId);

        var ms = new MemoryStream();

        await model.File.CopyToAsync(ms);

        var data = ms.ToArray();

        var fileUrl = GetFilePath();
        
        await File.WriteAllBytesAsync(fileUrl, data);
        
        var content = new Entities.Content()
        {
            FileUrl = fileUrl,
            Type = model.File.ContentType
        };

        var message = new Entities.Message()
        {
            FromUsrId = userId,
            FromUserName = user.UserName,
            ChatId = chatId,
            ContentId = content.Id,
            Content = content
            
        };
        
        await _unitOfWork.MessageRepository.AddMessage(message);
        
        return message.ParseToDto();
        
    }
    
    public string GetFilePath()
    {
        var generatPath = _hostEnvironment.ContentRootPath;

        var name = Guid.NewGuid();
        
        var fileName = generatPath + "\\wwwroot\\MessageFile\\" + name;
        
        return  fileName;
    }

    private async Task CheckingUserInChat(Guid userId, Guid chatId)
    {
        await _unitOfWork.UserChatRepository.GetUserChat(userId, chatId);
    }

  
    
}