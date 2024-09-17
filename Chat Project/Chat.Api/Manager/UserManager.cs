
using Chat.Api.DTOs;
using Chat.Api.Model.UserModels;
using Chat.Api.Repositories;

namespace Chat.Api.Manager;

public class UserManager(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;
    protected async Task<List<UserDto>> GetAllUsers(CreateUserModel mocel)
    {
        var users = await _userRepository.GetAllUsers();
    }
}     