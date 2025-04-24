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
            _logger.LogInformation("������� ������� ��������.");
            _logger.LogWarning("��������������: ���-�� ����� ����� �� ���.");
            _logger.LogError("��������� �� ������, ���������� ���������� ������.");
            _logger.LogDebug("���������� ����������. �� ��������� ��� ����� ���� ������.");
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
