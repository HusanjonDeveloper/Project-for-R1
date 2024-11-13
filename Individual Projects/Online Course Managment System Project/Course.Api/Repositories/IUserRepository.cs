using Course.Data.Entitiyes;

namespace Course.Data.Repositories;

public interface IUserRepository 
{
    Task CheckUserExist(string phoneNumber);
}