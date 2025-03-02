using Lab12._1.Model;
using Microsoft.AspNetCore.Mvc;

namespace Lab12._1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AppDbContext _db;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext context)
        {
            _logger = logger;
            _db = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            Student student = new Student { Name = "Кузьмина Полина", Age = 19, Group = "231-332" };
            _db.Students.Add(student);
            _db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult GetStudent()
        {
            var d = _db.Students.ToList();
            return Ok(d);
        }
    }
}