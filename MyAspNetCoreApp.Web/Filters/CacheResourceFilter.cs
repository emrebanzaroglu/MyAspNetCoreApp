using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyAspNetCoreApp.Web.Filters
{
    public class CacheResourceFilter : Attribute, IResourceFilter //bu filter için hazır bir sınıf olmadığından implemente etmemiz gerekiyor
    {
        private static IActionResult _cache; //static tanımlamamızın nedeni uygulama ayatka olduğu sürece değişken hep aktif olsun diye 
        public void OnResourceExecuted(ResourceExecutedContext context) //response üretildikten sonra çalışacak olan metod
        {
            _cache = context.Result; //context üzerinden gelen result'ı cacheliyoruz
        }

        public void OnResourceExecuting(ResourceExecutingContext context)  //ilk request girdiği anda çalışacak olan metod
        {
            if (_cache!=null)
            {
                context.Result = _cache;  //_cache eğer null değilse result'a cachelenmiş datayı verir.
            }
        }
    }
}
