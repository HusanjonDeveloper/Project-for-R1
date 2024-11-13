using Course.Data.Entitiyes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Course.Data.Context;

public class CourseDbContext : DbContext
{

    public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
    {
        
    }

    public  DbSet<User> Users { get; set; }
    
    public  DbSet<User_Course> UserCourses { get; set; }

    public  DbSet<Lesson> Lessons { get; set; }

    public  DbSet<Content> Contents { get; set; }

    public  DbSet<Data.Entitiyes.Course> Courses { get; set; }

    public  DbSet<Payment> Payments { get; set; }

    public DbSet<Course_Reports> CourseReports { get; set; }

    public  DbSet<CardInfo> CardInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var users = new List<User>();
        var user = new User
        {
            Id = Guid.NewGuid(),
            FristName = "Husan",
            LastName = "Muhammadaliyev",
            PhoneNumber = "08888888888"
        };
        
        string password = "123456";
        var hashedPass = new PasswordHasher<User>().HashPassword(user, password);
        user.PasswordHash = hashedPass;
        users.Add(user);
        modelBuilder.Entity<User>().HasData(users);
    }
}