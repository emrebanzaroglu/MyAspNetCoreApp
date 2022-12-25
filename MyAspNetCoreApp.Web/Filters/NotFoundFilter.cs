using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyAspNetCoreApp.Web.Models;
using System.Diagnostics;

namespace MyAspNetCoreApp.Web.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly AppDbContext _context;  //id'yi DB2den kontrol etmek için dbcontext nesnesi geçiyoruz

        public NotFoundFilter(AppDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var idValue = context.ActionArguments.Values.First(); //ActionArguments'e gidip ilk değeri alır. Arguments dediği metodun almış olduğu parametrelerdir. FirstorDefault da diyebilirdim ama zaten parametreleri olduğunu bildiğim için First dedim.
            var id = (int)idValue; //gelen değer object türündeydi bu sayede integer a dönüştürdük.

            var hasProduct = _context.Product.Any(x => x.Id == id);
            if (hasProduct==false)
            {
                context.Result = new RedirectToActionResult("Error", "Home",new ErrorViewModel()
                {
                    Errors= new List<string>() {$"Id({id})'ye sahip ürün veritabanında bulunamamıştır." }
                });
            }
        }
    }
}
