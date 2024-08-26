using Chat.Api.Context;

namespace Chat.Api.Repositories;

public class UnitOfWork(ChatDbContext context) : IUnitOfWork
{
    private IUserRepository? _userRepository { get;}

    public IUserRepository UserRepository
        => _userRepository ?? new UserRepository(context);
    

    public IChatRepositoriy? _chatRepositoriy { get;}
     
    public IChatRepositoriy ChatRepositoriy =>
         _chatRepositoriy ?? new ChatRepositoriy(context);

   
}