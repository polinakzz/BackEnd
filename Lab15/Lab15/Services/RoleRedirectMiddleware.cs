using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lab15.Services
{
    public class RoleRedirectMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleRedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Если пользователь не авторизован — пропускаем дальше
            if (!context.User.Identity.IsAuthenticated)
            {
                await _next(context);
                return;
            }

            // Пример: если пользователь с ролью "Admin" заходит на /User, перенаправим на /Admin
            var path = context.Request.Path.Value;

            if (context.User.IsInRole("Admin") && path.StartsWith("/User"))
            {
                context.Response.Redirect("/Admin");
                return;
            }
            if (context.User.IsInRole("User") && path.StartsWith("/Admin"))
            {
                context.Response.Redirect("/User");
                return;
            }

            await _next(context);
        }
    }

    public static class RoleRedirectMiddlewareExtensions
    {
        public static IApplicationBuilder UseRoleRedirect(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RoleRedirectMiddleware>();
        }
    }
}
