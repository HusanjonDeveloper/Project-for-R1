using Chat.Api.DTOs;
using Chat.Api.Entities;
using Mapster;

namespace Chat.Api.Extensions;

public static class ParseToDtoExtension
{
    public static UserDto ParseToDto(this User user)
    {
        UserDto dto = user.Adapt<UserDto>();
        return dto;
    }

    public static List<UserDto> ParseToDtos(this List<User>? users)
    {
        var dtos = new List<UserDto>();

        if (users == null || users.Count == 0)
            return dtos;
        dtos.AddRange(users .Select(x => x.ParseToDto()));
        return dtos;
    }
    
    
    public static ChatDto ParseToDto(this Entities.Chat chat)
    {
        ChatDto dto = chat.Adapt<ChatDto>();
        return dto;
    }

    public static List<ChatDto> ParseToDtos(this List<Entities.Chat>? chats)
    {
        var dtos = new List<ChatDto>();

        if (chats == null || chats.Count == 0)
            return dtos;

        dtos.AddRange(chats.Select(x => x.ParseToDto()));
        return dtos;
    } 
}