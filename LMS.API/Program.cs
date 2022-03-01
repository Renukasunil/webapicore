using LMS.Data;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore ;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using LMS.Service.Repository;

var builder = WebApplication.CreateBuilder(args);
//dependency 
builder.Services.AddScoped<IManageUser,ManageUser>();
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(item => item.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));


Console.WriteLine("Done");
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

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        Console.WriteLine("Migration Started");
        db.Database.Migrate();
    }
app.Run();
