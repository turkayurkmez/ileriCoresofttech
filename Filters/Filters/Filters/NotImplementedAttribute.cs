using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Filters.Filters
{
    public class NotImplementedAttribute  : ExceptionFilterAttribute
    {
        //Eğer bir action NotImplementedException döndürürse o request'e özel bir response döndür.
        //
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is NotImplementedException)
            {
                string message = $"ya kusura bakmayın bizim arkadaşlar yoğun da  {context.ActionDescriptor.DisplayName} ismli action'u yazamamışlar";

                context.Result = new ViewResult()
                {
                    ViewName = "NotImplemented",
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                    {
                        Model = message
                    }
                };
            }
        }

    }
}
