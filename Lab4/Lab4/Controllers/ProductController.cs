using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {
            new Product(1, "Ноутбук", 75000),
            new Product(2, "Смартфон", 45000),
            new Product(3, "Планшет", 32000)
        };

        [HttpGet("{id:int}")]
        public IActionResult GetProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(new { message = "Продукт не найден" });
            }
            return Ok(new { message = $"Продукт: {product.Name}, Цена: {product.Price} руб." });
        }

        [HttpGet("by-query")]
        public IActionResult GetProductByQuery([FromQuery] int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(new { message = "Продукт не найден" });
            }
            return Ok(new { message = $"Продукт: {product.Name}, Цена: {product.Price} руб." });
        }

        [HttpPost]
        public IActionResult CreateProduct([FromQuery] string name, [FromQuery] int price)
        {
            int newId = _products.Max(p => p.Id) + 1;
            var product = new Product(newId, name, price);
            _products.Add(product);
            return Ok(new { message = $"Продукт {name} с ценой {price} руб. добавлен" });
        }

        [HttpGet("all")]
        public IActionResult GetAllProducts()
        {
            return Ok(_products.Select(p => new { p.Id, p.Name, p.Price }));
        }
    }
}