using _4HWordPress.Api.Infrastructure;
using _4HWordPress.Core.Infrastructure;
using _4HWordPress.Core.IRepositories;
using _4HWordPress.Core.IServices;
using _4HWordPress.Data.Repositories;
using _4hWordPressAPI.Application.Services;
using _4hWordPressAPI.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.WithGlobalConnectionString("Server=localhost;port=3306;Database=dbjobs3;User Id=root;Password=123456;");
builder.Services.AddTransient<IPublishedActivityService, PublishedActivityService>();
builder.Services.AddTransient<IPublishedActivityRepository, PublishedActivityRepository>();
builder.Services.AddTransient<IConfigurationManager, _4HWordPress.Api.Infrastructure.ConfigurationManager>();
builder.Services.AddTransient<IConnectionFactory, ConnectionFactory>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
