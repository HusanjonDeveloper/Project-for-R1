
using Microsoft.EntityFrameworkCore;
namespace Chat.Api.Context;

public class ChatDbContext(DbContextOptions<ChatDbContext> options) : DbContext(options)
{
    public  DbSet<Entities.User> Users { get; set; }
    
    public DbSet<Entities.Chat> Chats { get; set; }

    public  DbSet<Entities.UserChat> UserChats { get; set; }

    public  DbSet<Entities.Message> Messages { get; set; }
}