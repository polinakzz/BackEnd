using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyConsoleApp
{
    public interface ICalculatorService  // Интерфейс сервиса
    {
        int Add(int a, int b);
    }

    public class CalculatorService : ICalculatorService  // Реализация сервиса
    {
        public int Add(int a, int b) => a + b;
    }

    class Program
    {
        static void Main(string[] args)
        {
            using var host = CreateHostBuilder().Build();
            var calculator = host.Services.GetRequiredService<ICalculatorService>();

            int result = calculator.Add(5, 3);
            Console.WriteLine($"5 + 3 = {result}");
        }

        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole(); // Добавляем логирование в консоль
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<ICalculatorService, CalculatorService>();
                });
    }
}