using Api;
using Game.Middleware;
using Game.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddScoped<RequestContext>()
	.AddMemoryCache()
	.AddApiService()
	.AddControllers();

var app = builder.Build();

app.UseMiddleware<RequestParser>();
app.UseMiddleware<ResponseCache>();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

app.Run();
