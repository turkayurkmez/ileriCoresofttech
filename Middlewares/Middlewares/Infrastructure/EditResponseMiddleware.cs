namespace Middlewares.Infrastructure
{
    public class EditResponseMiddleware 
    {
        private readonly RequestDelegate next;

        public EditResponseMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Items["IE"] as bool? == true)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }

            await next.Invoke(context);
        }
    }
}
