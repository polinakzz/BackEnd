var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Главная страница
app.MapGet("/", () => "Всем прив ^^");

// Страница "Мяу"
app.MapGet("/meow", () => "Это страница со словом MEOW.");

// Страница "Контакты"
app.MapGet("/contact", () => "Наши контакты: meowmeowmeow@ya.ru");

app.Run();
