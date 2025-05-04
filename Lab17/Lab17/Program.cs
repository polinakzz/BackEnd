var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache(); // Подключение встроенного кэша

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost"; // Redis работает на localhost
    options.InstanceName = "RedisDemo_"; // Префикс для ключей
});
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddResponseCaching();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseResponseCaching();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
