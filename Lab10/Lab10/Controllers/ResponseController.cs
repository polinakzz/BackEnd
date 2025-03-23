using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        // Метод для возврата HTML-страницы
        [HttpGet("html")]
        public IActionResult GetHtml()
        {
            string htmlContent = "<h1>Всем прив!</h1><p>Это html страница.</p>";
            return Content(htmlContent, "text/html");
        }

        // Метод для возврата JSON-данных
        [HttpGet("json")]
        public IActionResult GetJson()
        {
            var data = new { Message = "JSON ответ", Date = DateTime.Now };
            return Ok(data); // Возвращает 200 OK с JSON
        }

        // Метод для возврата файла
        [HttpGet("file")]
        public IActionResult GetFile()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "papka", "example.txt");
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(); // Возвращает 404, если файл не найден
            }
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/octet-stream", "example.txt");
        }
    }
}
