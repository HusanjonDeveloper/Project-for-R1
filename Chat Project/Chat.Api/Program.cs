
using System.Text;
using Chat.Api.Context;
using Chat.Api.Helpers;
using Chat.Api.Manager;
using Chat.Api.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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
            
            var jwtParam = builder.Configuration.
                GetSection("JwtParameters").Get<JwtParameters>();
            
            var key = System.Text.Encoding.UTF8.
                GetBytes(jwtParam.Key);
            
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = jwtParam.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = jwtParam.Audience,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true
                };
            });
            
            
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Bearer. : /Authorization:Bearer {token} \"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                
                c.AddSecurityRequirement( new OpenApiSecurityRequirement
                {

                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
            
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IChatRepositoriy, ChatRepositoriy>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();
            builder.Services.AddScoped<MessageManager>();
            builder.Services.AddScoped<UserManager>();
            builder.Services.AddScoped<ChatManager>();
            builder.Services.AddScoped<JwtManager>();
            builder.Services.AddScoped<UserHelper>();
            builder.Services.AddScoped<IUserChatRepository, UserChatRepository>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<MemoryCacheManager>();
            builder.Services.AddMemoryCache();
        
             
            builder.Services.AddDbContext<ChatDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("ChatDb")); 
            }); 
 
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
