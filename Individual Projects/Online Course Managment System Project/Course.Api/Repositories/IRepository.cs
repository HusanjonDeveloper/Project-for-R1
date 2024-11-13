namespace Course.Data.Repositories;

public interface IRepository<T>
{
    Task Create(T model);
}