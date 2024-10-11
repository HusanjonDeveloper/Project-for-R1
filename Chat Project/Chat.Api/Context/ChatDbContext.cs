namespace Chat.Api.Context;
public class ChatDbContext(DbContextOptions<ChatDbContext> options) : DbContext(options)
{
    public  DbSet<Entities.User> Users { get; set; }
    
    public DbSet<Entities.Chat> Chats { get; set; }

    public  DbSet<Entities.UserChat> UserChats { get; set; }

    public  DbSet<Entities.Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var password = "admin";   
        
        var user =  new User()
        {
            Id = Guid.NewGuid(),
            FirstName = "admin",
            LastName = "admin",
            UserName = "admin",
            Gender = UserConstants.Male,
            Role = UserConstants.AdminRole
        };

        var passwordHash = new PasswordHasher<User>().HashPassword(user, password);
        user.PasswordHash = passwordHash;
        
        // seed data 
        modelBuilder.Entity<User>().HasData( new List<User>()
        {
            user
        });
    }
}