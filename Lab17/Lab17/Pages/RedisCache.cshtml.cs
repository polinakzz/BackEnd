using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;

namespace Lab17.Pages
{
    public class RedisCacheModel : PageModel
    {
        private readonly IDistributedCache _cache;

        public RedisCacheModel(IDistributedCache cache)
        {
            _cache = cache;
        }

        public string CachedTime { get; set; }
        public string CurrentTime { get; set; }

        public async Task OnGetAsync()
        {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            CachedTime = await _cache.GetStringAsync("RedisCachedTime");

            if (CachedTime == null)
            {
                CachedTime = DateTime.Now.ToString("HH:mm:ss");
                await _cache.SetStringAsync("RedisCachedTime", CachedTime, new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromSeconds(20)
                });
            }
        }
    }
}