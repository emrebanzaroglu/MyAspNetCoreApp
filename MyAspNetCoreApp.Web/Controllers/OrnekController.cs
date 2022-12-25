using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Filters;

namespace   MyAspNetCoreApp.Web.Controllers
{
    public class OrnekController : Controller
    {
        [CustomResultFilter("x-version","1.0")]
        public IActionResult Index()
        {
            ViewBag.name = "Asp.Net Core";
            ViewData["age"] = 30;
            ViewData["names"] = new List<string>() { "ahmet", "mehmet", "hasan" };
            ViewBag.person = new { Id = 1, Name = "Emre", Age = 25 };
            TempData["surname"] = "banzar"; //başka viewlere veri taşıyabilir.

            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult Index3()
        {
            return RedirectToAction("Index", "Ornek"); //OrnekController'daki Index sayfasına yönlendirmeye yarar.
        }
        public IActionResult ParameterView(int id)
        {
            return RedirectToAction("JsonResultParameter", "Ornek", new { ID = id }); //ilk ID aşağıdaki metodun, ikinci id ise bu metodun
        }

        public IActionResult JsonResultParameter(int ID)
        {
            return Json(new { Id = ID });
        }
        public IActionResult ContentResult()  //sayfa yerine string ifade döndürmek istediğimizde
        {
            return Content("ContentResult");
        }
        public IActionResult JsonResult() //Ajax modelinde veri döndürmek istediğimizde
        {
            return Json(new { Id = 1, name = "Kalem", price = 100 });
        }
        public IActionResult EmptyResult() //boş döndürmek istediğimizde
        {
            return new EmptyResult();
        }

    }
}
