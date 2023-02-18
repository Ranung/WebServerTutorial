using Api;
using Game.Context;
using Game.Middleware;
using Game.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IConfigurationRoot configurationRoot = builder.Configuration;
var dbConnectionString = configurationRoot.GetConnectionString("MySQL")!;

builder.Services
    .AddScoped<RequestContext>()
    .AddDbContext<GameContext>(options => options.UseMySQL(dbConnectionString))
    .AddMemoryCache()
    .AddApiService()
    .AddControllers();

var app = builder.Build();

app.UseMiddleware<RequestParser>();
app.UseMiddleware<ResponseCache>();

app.MapControllers();

app.Run();