using System.Diagnostics;
using Lab7.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Открыта главная страница.");
            _logger.LogWarning("Предупреждение: что-то может пойти не так.");
            _logger.LogError("Сообщение об ошибке, приложение продолжает работу.");
            _logger.LogDebug("Отладочная информация. По умолчанию она может быть скрыта.");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
