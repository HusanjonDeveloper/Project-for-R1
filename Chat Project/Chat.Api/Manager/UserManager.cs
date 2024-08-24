
using Chat.Api.Context;
using Chat.Api.Model.UserModels;

namespace Chat.Api.Manager;

public class UserManager(ChatDbContext context)
{
     private readonly ChatDbContext _context = context;

     public async Task Register(CreateUserModel model)
     {
          
     }
     
}