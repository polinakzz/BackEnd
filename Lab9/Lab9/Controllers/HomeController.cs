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

        // ��������� ����������
        public IActionResult ThrowException()
        {
            throw new Exception("��������� �������������� ������.");
        }

        // ��������� ������ ���� ������
        public IActionResult ThrowDbException()
        {
            throw new InvalidOperationException("������ ��� ����������� � ���� ������.");
        }

        // �������� ��������� ����������
        public IActionResult Error()
        {
            return View("Error");
        }

        // ��������� ������ �� ����
        public IActionResult StatusCode(int code)
        {
            if (code == 404)
                return View("Error404");
            return View("Error");
        }
    }
}
