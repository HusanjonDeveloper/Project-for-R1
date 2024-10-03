
using Chat.Api.Constants;
using Chat.Api.DTOs;
using Chat.Api.Entities;
using Chat.Api.Exceptions;
using Chat.Api.Extensions;
using Chat.Api.Model.UserModels;
using Chat.Api.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Chat.Api.Manager;

public class UserManager( IUnitOfWork unitOfWork, JwtManager jwtManager, MemoryCacheManager cacheManager)
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    private readonly JwtManager _jwtManager = jwtManager;

    private readonly MemoryCacheManager _cacheManager = cacheManager;

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

        var token = _jwtManager.GenerateToken(user);

        return token;
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
    
    public async Task<UserDto> UpdateBio(Guid userId, string bio)
    {
        var user = await _unitOfWork.UserRepository.GetUserById(userId);
        if (!string.IsNullOrEmpty(bio)) {

            user.Bio = bio;
            await _unitOfWork.UserRepository.UpdateUser(user);
        }
        await Set();
        return user.ParseToDto();
    }
    
    public async Task<UserDto> UpdateUserGeneralInfo(Guid userId, UpdateUserGeneralInfo info)
    {
        var user = await _unitOfWork.UserRepository.GetUserById(userId);

        bool check = false;
        
        if (!string.IsNullOrEmpty(info.Firstname))
        {
            user.FirstName = info.Firstname;
            check = true;
        }
        
        if (!string.IsNullOrEmpty(info.Lastname))
        {
            user.LastName = info.Lastname;
            check = true;
        }
        
        if (!string.IsNullOrEmpty(info.Age))
        {
           
            try
            {
                byte age = byte.Parse(info.Age);

                user.Age = age;
                check = true;
            }
            catch (Exception e)
            {
                throw new Exception("Age must be number");
            }
        }

        if (check)
        {
            await _unitOfWork.UserRepository.UpdateUser(user);
            await Set();
        }

        return user.ParseToDto();
    }
    
    public async Task<UserDto> UpdateUsername(Guid userId,UpdateUsernameModel model )
    {
        var user = await _unitOfWork.UserRepository.GetUserById(userId);

        await CheckForExist(model.Username);

        user.Username = model.Username;

        await _unitOfWork.UserRepository.UpdateUser(user);

        await Set();
        return user.ParseToDto();

    }

    private async Task Set()
    {
        var users = await _unitOfWork.UserRepository.GetAllUsers();
        _cacheManager.GetOrUpdateDtos(Key,users.ParseToDtos());
    }

    
}     