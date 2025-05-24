using System.Diagnostics;
using Lab9.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab9.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Генерация исключения
        public IActionResult ThrowException()
        {
            throw new Exception("Произошла непредвиденная ошибка.");
        }

        // Имитируем ошибку базы данных
        public IActionResult ThrowDbException()
        {
            throw new InvalidOperationException("Ошибка при подключении к базе данных.");
        }

        // Страница обработки исключений
        public IActionResult Error()
        {
            return View("Error");
        }

        // Обработка ошибок по коду
        public IActionResult StatusCode(int code)
        {
            if (code == 404)
                return View("Error404");
            return View("Error");
        }
    }
}
