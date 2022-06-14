using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Filters.Filters
{
    public class StopwatchAttribute : ActionFilterAttribute
    {
        private readonly Stopwatch _stopwatch;

        public StopwatchAttribute()
        {
            _stopwatch = new Stopwatch();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            //action çalışırken, eğer parametre kolntrolü yapılacaksa, bu parametre değerinin QueryString'de olduğu unutulmamalı
            //if (context.ActionArguments.ContainsKey("isStopWatch"))
            //{

            //    if (context.ActionArguments["isStopWatch"].ToString() == "True")
            //    {

            //    }

            //}
            _stopwatch.Start();



        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            context.HttpContext.Response.Headers.Add("X-Stopwatch", _stopwatch.ElapsedMilliseconds.ToString());

            //Üç yöntemle istemciye bilgi dönebilirsiniz
            //1. View içerisindeki model ile
            //2. View içerisindeki ViewBag.Stopwatch ile
            //3. View içerisindeki ViewData["Stopwatch"] ile
            var result = context.Result as ViewResult;
            if (result != null)
            {
                result.ViewData["Stopwatch"] = _stopwatch.ElapsedMilliseconds;
            }
      
            //4. Response.WriteAsync ile


        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            return base.OnActionExecutionAsync(context, next);
        }
    }
}
