using MySql.Data.MySqlClient;
using FluentValidation;
using System.Reflection;
using FluentValidation.AspNetCore;
using UkrMobilServiceNotes.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration
                                  .SetBasePath(builder.Environment.ContentRootPath)
                                  .AddJsonFile("appsettings.json")
                      .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json")
                      .AddEnvironmentVariables()
                      .Build();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(Configuration["ConnectionStrings:Default"]));

builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
        {
            var connetionString = Configuration["ConnectionStrings:Default"];
            options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
        });
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddTransient<INotesRepository, NotesRepository>();

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
