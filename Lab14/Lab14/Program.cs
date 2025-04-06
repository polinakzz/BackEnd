var builder = WebApplication.CreateBuilder(args);

// Регистрируем CORS-политику
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", policy =>
    {
        policy.AllowAnyOrigin() 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
