using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace Lab17.Pages
{
    public class CachedTimeModel : PageModel
    {
        private readonly IMemoryCache _cache;

        public CachedTimeModel(IMemoryCache cache)
        {
            _cache = cache;
        }

        public string CachedTime { get; set; }
        public string CurrentTime { get; set; }

        public void OnGet()
        {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");

            // Пробуем получить время из кэша
            if (!_cache.TryGetValue("CachedTime", out string cachedTime))
            {
                // Если в кэше нет, то сохраняем
                cachedTime = DateTime.Now.ToString("HH:mm:ss");
                _cache.Set("CachedTime", cachedTime, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromSeconds(10) // Кэш живёт 10 секунд
                });
            }

            CachedTime = cachedTime;
        }
    }
}