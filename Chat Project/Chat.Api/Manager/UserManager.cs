 
using Chat.Api.Constants;
using Chat.Api.DTOs;
using Chat.Api.Entities;
using Chat.Api.Exceptions;
using Chat.Api.Extensions;
using Chat.Api.Model.UserModels;
using Chat.Api.Repositories;

namespace Chat.Api.Manager;

public class UserManager(IUserRepository userRepository)
{
     private readonly IUserRepository _userRepository = userRepository;

     public async Task<List<UserDto >> GetAllUsers()
     {
         var users = await _userRepository.GetAllUsers();

         return users.ParsToDto();
     }

     public async Task<UserDto> GetUserById(Guid userId)
     {
         var user = await _userRepository.GetUserById(userId);
         return user.ParsToDto();
     }

     public async Task<UserDto> Register(CreateUserModel model)
     {
         await CheckForExist(model.UserName);

         var user = new User()
         {
             FirstName = model.FirstName,
             LastName = model.LastName,
             UserName = model.UserName,
             Gender = GetGender(model.Gender)
         };
         
         
     }

     private async Task CheckForExist(string username)
     {
         var user = await _userRepository.GetUserByUsername(username);
       
         if (user is null)
             throw new UserExsitException();
     }

     private string GetGender(string gender)
     {
         var checkingForGenderExist = gender.ToLower() == UserConstants.Male ||
                                      gender.ToLower() == UserConstants.Famale;

         return checkingForGenderExist ? gender : UserConstants.Male;
     }

}