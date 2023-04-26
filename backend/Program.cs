using MySql.Data.MySqlClient;
using FluentValidation;
using System.Reflection;
using FluentValidation.AspNetCore;

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
builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(Configuration["ConnectionStrings:Default"]));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation();

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
