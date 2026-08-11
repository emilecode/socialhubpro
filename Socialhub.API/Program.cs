using Microsoft.EntityFrameworkCore;
using Socialhub.API.DataBase;
using Socialhub.API.Interfaces;
using Socialhub.API.Services;


var builder = WebApplication.CreateBuilder(args);
string connectionString = "PostgresConnection";
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString(connectionString)
    );
});
builder.Services.AddScoped<IUserService, UserService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
// app.UseHttpsRedirection()

app.Run();


