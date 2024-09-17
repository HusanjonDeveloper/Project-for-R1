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

        foreach (var user in users)
        {
            dtos.Add(user.ParseToDto());
        }

        return dtos;
    }
}