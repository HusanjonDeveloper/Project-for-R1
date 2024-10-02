using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    var key = "asdsadskdfjhskjh1232384763246";
    
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = "Chat.Api",
        ValidateIssuer = true,
        ValidAudience = "Chat.Client",
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF32.GetBytes(key)),
        ValidateIssuerSigningKey = true
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

