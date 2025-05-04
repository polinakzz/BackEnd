using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab17.Pages
{
    public class ResponseCachedPageModel : PageModel
    {
        public string CurrentTime { get; set; }

        public void OnGet()
        {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}