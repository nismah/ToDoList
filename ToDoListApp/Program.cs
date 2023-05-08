using Microsoft.EntityFrameworkCore;
using ToDoListApp.Data;
using ToDoListApp.Data.Context;
using ToDoListApp.Data.Models;
using ToDoListApp.Services;

var builder = WebApplication.CreateBuilder(args);
bool createDb = builder.Configuration.GetValue<bool>("AddDbData");

if (createDb)
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
var connectionString = builder.Configuration.GetValue<string>("ConnectionString");

// Add services to the container.
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile));

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

if (createDb)
{
    using (var context = new ToDoListDbContext())
    {
        context.Database.EnsureCreated();
        context.SaveChanges();
    }
}

app.Run();
