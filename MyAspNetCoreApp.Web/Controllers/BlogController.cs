using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class BlogController : Controller
    {
        // blog/article/makale-ismi/id   sağdaki ikili dinamik değişen yapılar, soldakiler sabit yapılar
        public IActionResult Article(string name,int id)  //name makale ismi, id makale id 
        {
            //var routes = Request.RouteValues["article"];
            return View();
        }
    }
}
