using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters
{
    public class IsExistsAttribute : TypeFilterAttribute
    {
        public IsExistsAttribute() : base(typeof(ItemExistsFilter))
        {
        }
        //public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{

        //    if (!context.ActionArguments.ContainsKey("id"))
        //    {
        //        context.Result = new BadRequestObjectResult("Id değeri gereklidir");
        //        return;
        //    }

        //    if (!(context.ActionArguments["id"] is int id))
        //    {
        //        context.Result = new BadRequestObjectResult("Id değeri int olmalıdır");
        //        return;

        //    }

        //    //kontrol et: db'de id'ye ait bir kayıt var mı?
        //    await next();



        //}

        //public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        //{
        //    return base.OnResultExecutionAsync(context, next);
        //}
    }
}
