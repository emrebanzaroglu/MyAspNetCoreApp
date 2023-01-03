using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class AppSettingsController : Controller
    {
        private readonly IConfiguration _configuration;

        public AppSettingsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.baseUrl = _configuration["baseUrl"]; // appsettings.json doyasındaki key'i böyle de yazabiliriz. Tek değer varsa tercih edilir.
            ViewBag.smsKey = _configuration["Keys:Sms"]; // ya da üst dalına gidip içe gire gire yazarız.
            ViewBag.emailKey = _configuration.GetSection("Keys")["email"]; // ya da böyle yaparız. Keys'de birden fazla key olduğu için hangisi olduğunu yazarız

            return View();
        }
    }
}
