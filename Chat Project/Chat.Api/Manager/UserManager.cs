 
using Chat.Api.Constants;
using Chat.Api.DTOs;
using Chat.Api.Entities;
using Chat.Api.Exceptions;
using Chat.Api.Extensions;
using Chat.Api.Model.UserModels;
using Chat.Api.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Chat.Api.Manager;

public class UserManager(IUnitOfWork unitOfWork)
{
    private readonly IUnitOfWork  _unitOfWork = unitOfWork;

     public async Task<List<UserDto >> GetAllUsers()
     {
         var users = await _unitOfWork.UserRepository.GetAllUsers();

         return users.ParsToDto();
     }

     public async Task<UserDto> GetUserById(Guid userId)
     {
         var user = await _unitOfWork.UserRepository.GetUserById(userId);
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

         var passwordHash =
             new PasswordHasher<User>()
                 .HashPassword(user, model.Password);

         user.PasswordHash = passwordHash;

         await _unitOfWork.UserRepository.AddUser(user);
         return user.ParsToDto();
     }

     public async Task<string> Login(LoginModel model)
     {
         var user = await _unitOfWork.UserRepository.GetUserByUsername(model.UserName);

         if (user is null)
             throw new Exception("UserName is invalid");

         var result =
             new PasswordHasher<User>()
                 .VerifyHashedPassword(user, user.PasswordHash, model.Password);

         if (result == PasswordVerificationResult.Failed)
             throw new Exception("Invalid password");

         return "Login successfully";

     }
 
     private async Task CheckForExist(string username)
     {
         var user = await _unitOfWork.UserRepository.GetUserByUsername(username);
       
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