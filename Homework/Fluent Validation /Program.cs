using Fluent_Validation.Model;
using Fluent_Validation.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CreateUserModel>();
builder.Services.AddScoped<GeneralInfoModel>();
builder.Services.AddScoped<LoginModel>();
builder.Services.AddScoped<TextModel>();
builder.Services.AddScoped<UpdateUsernameModel>();
builder.Services.AddScoped<CreateUserModelValidator>();

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