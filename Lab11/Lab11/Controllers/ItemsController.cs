using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Lab11.Models; // Подключаем пространство имен с моделью

namespace Lab11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private static List<Item> items = new List<Item>
        {
            new Item { Id = 1, Name = "Item1" },
            new Item { Id = 2, Name = "Item2" },
            new Item { Id = 3, Name = "Item3" }
        };

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return items;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Item newItem)
        {
            if (newItem == null || string.IsNullOrWhiteSpace(newItem.Name))
            {
                return BadRequest("Элемент не может быть пустым.");
            }

            newItem.Id = items.Any() ? items.Max(i => i.Id) + 1 : 1; // Генерируем новый ID
            items.Add(newItem);
            return Ok(newItem);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Item updatedItem)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound("Элемент не найден.");
            }

            if (string.IsNullOrWhiteSpace(updatedItem.Name))
            {
                return BadRequest("Элемент не может быть пустым.");
            }

            item.Name = updatedItem.Name;
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound("Элемент не найден.");
            }

            items.Remove(item);
            return Ok($"Удален: {item.Name}");
        }
    }
}
