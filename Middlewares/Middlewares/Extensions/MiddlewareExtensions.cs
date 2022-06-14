using Middlewares.Infrastructure;

namespace Middlewares.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCheckBrowserIsIE(this IApplicationBuilder app)
        {
            app.UseMiddleware<IECheckMiddleware>();
            app.UseMiddleware<EditResponseMiddleware>();
            app.UseMiddleware<RedirectToPageMiddleware>();

            return app; 
        }

    }
}
