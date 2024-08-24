
using Microsoft.EntityFrameworkCore;

namespace Chat.Api.Context;

public class ChatDbContext : DbContext
{
    
    public ChatDbContext()
    {
        // Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LAPTOP-1FG38VDK;Database=Chat.Api; Integrated Security=true;TrustServerCertificate=True;");
    }
    
    public  DbSet<Entities.User> Users { get; set; }
    
    public DbSet<Entities.Chat> Chats { get; set; }

    public  DbSet<Entities.UserChat> UserChats { get; set; }

    public  DbSet<Entities.Message> Messages { get; set; }
}