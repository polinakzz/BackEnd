var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

Console.WriteLine($"ENVIRONMENT: {builder.Environment.EnvironmentName}");

var config = builder.Configuration;

string appName = config["MySettings:ApplicationName"];
string version = config["MySettings:Version"];

Console.WriteLine($"Application Name: {appName}");
Console.WriteLine($"Version: {version}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
