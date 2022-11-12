using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class OrnekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return RedirectToAction("Index","Ornek"); //OrnekController'daki Index sayfasına yönlendirmeye yarar.
        }
        public IActionResult ContentResult()  //sayfa yerine string ifade döndürmek istediğimizde
        {
            return Content("ContentResult");
        }
        public IActionResult JsonResult() //Ajax modelinde veri döndürmek istediğimizde
        {
            return Json(new { Id=1,name="Kalem",price=100});
        }
        public IActionResult EmptyResult() //boş döndürmek istediğimizde
        {
            return new EmptyResult();
        }

    }
}
