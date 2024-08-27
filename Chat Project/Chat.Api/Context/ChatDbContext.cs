
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Chat.Api.Context;

public class ChatDbContext: DbContext
{


    public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
    {

    }


    public  DbSet<Entities.User> Users { get; set; }
    
    public DbSet<Entities.Chat> Chats { get; set; }

    public  DbSet<Entities.UserChat> UserChats { get; set; }

    public  DbSet<Entities.Message> Messages { get; set; }
}