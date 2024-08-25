namespace Chat.Api.Repositories;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; set; }

    IChatRepositoriy ChatRepositoriy { get; }
}