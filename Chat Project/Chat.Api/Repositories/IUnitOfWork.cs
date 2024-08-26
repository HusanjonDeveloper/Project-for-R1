namespace Chat.Api.Repositories;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get;}

    IChatRepositoriy ChatRepositoriy { get; }
}