using Microsoft.AspNetCore.Mvc;

namespace Lab8.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index()
        {
            // Читаем имя из сессии и cookie
            ViewBag.SessionName = HttpContext.Session.GetString("UserName");
            ViewBag.CookieName = Request.Cookies["UserName"];
            return View();
        }

        [HttpPost]
        public IActionResult Save(string name)
        {
            // Сохраняем в сессию
            HttpContext.Session.SetString("UserName", name);

            // Сохраняем в cookie
            Response.Cookies.Append("UserName", name, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddMinutes(30)
            });

            return RedirectToAction("Index");
        }
    }
}
