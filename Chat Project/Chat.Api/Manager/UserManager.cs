
using Chat.Api.Constants;
using Chat.Api.DTOs;
using Chat.Api.Entities;
using Chat.Api.Exceptions;
using Chat.Api.Extensions;
using Chat.Api.Model.UserModels;
using Chat.Api.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Chat.Api.Manager;

public class UserManager( IUnitOfWork unitOfWork)
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<List<UserDto>> GetAllUsers()
    {
        var users = await _unitOfWork.UserRepository.GetAllUsers();

        return users.ParseToDtos();
    }

    public async Task<UserDto> GetUsrById(Guid userId)
    {
        var user = await _unitOfWork.UserRepository.GetUserById(userId);
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

         await _unitOfWork.UserRepository.AddUser(user);
         return user.ParseToDto();
    }
    
    private async Task CheckForrExist(string username)
    {
         var user  =  await _unitOfWork.UserRepository.GetUserByUsername(username);

         if (user is null)
             throw new UserExsitException();
    }

    public async Task<string> Login(LoginModel model)
    {
        var user = await _unitOfWork.UserRepository.GetUserByUsername(model.UserName);
       
        if(user is null)
            throw new Exception("Invalid username");

        var result = new PasswordHasher<User>().
            VerifyHashedPassword(user, user.PasswordHash, model.Password);

        if (result == PasswordVerificationResult.Failed)
            throw new Exception("Invalid  password");

        return "Login Successful";
    }

    public async Task<byte[]> AddOrUpdatePhoto(Guid userId,IFormFile file)
    {

        var  user = await _unitOfWork.UserRepository.GetUserById(userId);

        var check = Helpers.StaticHelper.IsPhoto(file);
        
         
        if (!check)
            throw new NotPhotoType();
        
        var data = Helpers.StaticHelper.GetData(file);
        
        user.PhotoData = data;
        
        await _unitOfWork.UserRepository.UpdateUser(user);
        
        return data;

    }

    private string GetGender(string gender)
    {
        var checkForGenderExist = gender.ToLower() == UserConstants.Male
                                   || gender.ToLower() == UserConstants.Female;
        
        return checkForGenderExist ? gender : UserConstants.Male;
    }

    
}     