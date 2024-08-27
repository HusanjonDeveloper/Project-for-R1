
using Chat.Api.Context;
using Chat.Api.Manager;
using Chat.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chat.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IChatRepositoriy, ChatRepositoriy>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<UserManager>();
            
            builder.Services.AddDbContext<ChatDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetSection("ChatDb").Value); 
            });
 
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
