using Microsoft.EntityFrameworkCore;
using SQLTutorial.Models;

namespace SQLTutorial.Context;

public class AppDbContext : DbContext
{
     public  DbSet<Category> Categories { get; set; }
     public  DbSet<Product> Products { get; set; }
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
          optionsBuilder.UseNpgsql("User ID=postgres;Password=20010410;Host=localhost;Port=5432;Database=TutorialDb;");
     }


     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
          var categories =
               new List<Category>()
               {
                    
                    new Category()
                    {
                         Id = 1,
                         Name = "Name1"
                    },
                    new Category()
                    {
                         Id = 2,
                         Name = "Name2"
                    },
                    new Category()
                    {
                         Id = 3,
                         Name = "Name3"
                    },
                    new Category()
                    {
                         Id = 4,
                         Name = "Name4"
                    },
                    new Category()
                    {
                         Id = 5,
                         Name = "Name5"
                    },
                    new Category()
                    {
                         Id = 6,
                         Name = "Name6"
                    }
               };
          
          modelBuilder.Entity<Category>()
               .HasData(new List<Category>(categories));
     }
}