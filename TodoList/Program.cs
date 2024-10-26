using Microsoft.EntityFrameworkCore;
using TodoList.DAL;
using TodoList.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(connectionString);
    optionsBuilder.EnableSensitiveDataLogging();
});
builder.Services.AddScoped<AssignmentService>();

var app = builder.Build();
app.MapControllers();
app.Run();