var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ������� ��������
app.MapGet("/", () => "���� ���� ^^");

// �������� "���"
app.MapGet("/meow", () => "��� �������� �� ������ MEOW.");

// �������� "��������"
app.MapGet("/contact", () => "���� ��������: meowmeowmeow@ya.ru");

app.Run();
