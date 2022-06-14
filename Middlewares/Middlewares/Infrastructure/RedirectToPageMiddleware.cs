namespace Middlewares.Infrastructure
{
    public class RedirectToPageMiddleware
    {
        private readonly RequestDelegate _next;

        public RedirectToPageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Response.StatusCode == StatusCodes.Status400BadRequest)
            {
                context.Request.Path = "/error/400.html";
            }
          
             await _next(context);
           
        }
    }
}
