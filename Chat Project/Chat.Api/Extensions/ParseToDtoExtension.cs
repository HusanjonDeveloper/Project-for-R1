using Chat.Api.DTOs;
using Chat.Api.Entities;
using Mapster;

namespace Chat.Api.Extensions;

public static class ParseToDtoExtension
{
    public static UserDto ParsToDto(this User user)
    {
        UserDto dto = user.Adapt<UserDto>();
        return dto;
    }

    public static List<UserDto> ParsToDto(this List<User>? users)
    {
        var dtos = new List<UserDto>();

        if (users == null || users.Count == 0)
            return dtos;

        dtos.AddRange(users.Select(user => user.ParsToDto()));

        return dtos;
    }
    
}