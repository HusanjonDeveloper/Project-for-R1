namespace Chat.Api.Repositories;

public interface IChatRepositoriy
{
    Task<List<Entities.Chat>> GetAllChats();
}