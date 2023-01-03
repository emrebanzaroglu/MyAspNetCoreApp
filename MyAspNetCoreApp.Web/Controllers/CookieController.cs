using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult CookieCreate()
        {
            HttpContext.Response.Cookies.Append("background-color","red",new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(2)  //cookie'nin 2 gün geçerli olmasını sağlar
            }); //Cookie ekleme
            return View();
        }

        public IActionResult CookieRead() 
        {
            var bgcolor = HttpContext.Request.Cookies["background-color"];
            ViewBag.bgcolor = bgcolor;
            return View();
        }
    }
}
