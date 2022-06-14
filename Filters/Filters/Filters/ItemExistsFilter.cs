using Filters.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters
{
    public class ItemExistsFilter : IAsyncActionFilter
    {
        private IProductService _productService;

        public ItemExistsFilter(IProductService productService)
        {
            _productService = productService;

        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult("Id değeri gereklidir");
                return;
            }

            if (!(context.ActionArguments["id"] is int id))
            {
                context.Result = new BadRequestObjectResult("Id değeri int olmalıdır");
                return;

            }

            //kontrol et: db'de id'ye ait bir kayıt var mı?
            var isFound = _productService.isExists(id);

            if (!isFound)
            {
                context.Result = new NotFoundObjectResult("Id değeri veritabanında bulunamadı");
                return;
            }
            await next();
        }
    }
}
