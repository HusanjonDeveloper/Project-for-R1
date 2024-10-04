using Chat.Api.DTOs;
using Chat.Api.Extensions;
using Chat.Api.Model;
using Chat.Api.Repositories;
using NuGet.Protocol.Plugins;

namespace Chat.Api.Manager;

public class MessageManager(IUnitOfWork unitOfWork)
{
    // 1 GetMessage
    // 2 GetChatMessage
    // 3 GetMessageById
    // 4 GetChatMessageById
    // 5 SendMessage
    
    private  readonly IUnitOfWork _unitOfWork = unitOfWork;

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

    public async Task<MessageDto> SendTextMessage(Guid userId, TextModel model)
    {
        var user = await _unitOfWork.UserRepository.GetUserById(userId);
        
        var message = new  Entities.Message()
        {
            Text = model.Text,
            FromUsrId = userId,
            FromUserName = user.UserName,
            ChatId = model.ChatId
        };

        await _unitOfWork.MessageRepository.AddMessage(message);

        return message.ParseToDto();
    }
    
    
    /*
    public async Task<MessageDto> SendFileMessage()
    {
        var message = new Entities.Message()
        {

        };

        await _unitOfWork.MessageRepository.AddMessage(message);
        
    }
    */
    
    
}