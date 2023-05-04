using Microsoft.EntityFrameworkCore;
using ToDoListApp.Data.Context;
using ToDoListApp.Data.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetValue<string>("ConnectionString");
bool addDbData = builder.Configuration.GetValue<bool>("AddDbData");
#region DbContext
builder.Services.AddDbContext<ToDoListDbContext>(options =>
{
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging(true);
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 1, 40)));
}, contextLifetime: ServiceLifetime.Scoped,
optionsLifetime: ServiceLifetime.Singleton);

#endregion DbContext

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

if (addDbData)
{
    using (var context = new ToDoListDbContext())
    {
        //Add roles
        context.Database.EnsureCreated();
        context.Roles.Add(new Role() { EmployeeRole = "Manager" });
        context.Roles.Add(new Role() { EmployeeRole = "Supervisor" });
        context.Roles.Add(new Role() { EmployeeRole = "Member" });
        context.SaveChanges();
    }
}
app.Run();
