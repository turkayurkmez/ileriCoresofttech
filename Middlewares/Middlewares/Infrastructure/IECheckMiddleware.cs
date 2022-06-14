namespace Middlewares.Infrastructure
{
    public class IECheckMiddleware
    {
        private readonly RequestDelegate next;

        public IECheckMiddleware(RequestDelegate next)
        {
            this.next = next;

        }
        
        public async Task Invoke(HttpContext httpContext)
        {
            var userAgent = httpContext.Request.Headers["User-Agent"].ToString().Contains("Trident");
            httpContext.Items["IE"] = userAgent;    

            Console.WriteLine("Dikkat!!! ");
            Console.WriteLine(userAgent);

            await next(httpContext);
        }
    }
}
