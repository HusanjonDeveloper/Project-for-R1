
using Chat.Api.Constants;
using Chat.Api.DTOs;
using Chat.Api.Entities;
using Chat.Api.Exceptions;
using Chat.Api.Extensions;
using Chat.Api.Model.UserModels;
using Chat.Api.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Chat.Api.Manager;

public class UserManager(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;
    protected async Task<List<UserDto>> GetAllUsers(CreateUserModel mocel)
    {
        var users = await _userRepository.GetAllUsers();

        return users.ParseToDtos();
    }

    public async Task<UserDto> GetUsrById(Guid userId)
    {
        var user = await _userRepository.GetUserById(userId);
        return user.ParseToDto();
    }

    public async Task<UserDto> Register(CreateUserModel model)
    {
        await CheckForrExist(model.UserName);

        var user = new User()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.UserName,
            Gender = GetGender(model.Gender)
        };
        
        var passwordHash = new PasswordHasher<User>()
                                .HashPassword(user, model.Password);
                           
         user.PasswordHash = passwordHash;

         await _userRepository.AddUser(user);
         return user.ParseToDto();
    }
    
    private async Task CheckForrExist(string username)
    {
         var user  =  await _userRepository.GetUserByUsername(username);

         if (user is null)
             throw new UserExsitException();
    }

    private string GetGender(string gender)
    {
        var checkForGenderExist = gender.ToLower() == UserConstants.Male
                                   || gender.ToLower() == UserConstants.Female;
        
        return checkForGenderExist ? gender : UserConstants.Male;
    }
}     