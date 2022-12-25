using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MyAspNetCoreApp.Web.Filters
{
    public class LogFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)  //action metod çalışmadan önce
        {
            Debug.WriteLine("Action Method çalışmadan önce");
            //base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)  //action metod çalıştıktan sonra
        {
            Debug.WriteLine("Action Method çalıştıktan sonra");
            //base.OnActionExecuted(context);
         }
        public override void OnResultExecuting(ResultExecutingContext context)  //sonuç üretilmeden önce
        {
            Debug.WriteLine("Action Method sonuç üretilmeden önce");

            //base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)  //sonuç üretildikten sonra
        {
            Debug.WriteLine("Action Method sonuç üretildikten sonra");
            //base.OnResultExecuted(context);
        }
    }
}
