using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;
using System.Diagnostics;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ProductListPartialViewModelMethod();
            return View();
        }

        

        public IActionResult Privacy()
        {
            ProductListPartialViewModelMethod();
            return View();
        }
        private void ProductListPartialViewModelMethod()
        {
            var products = _context.Product.OrderByDescending(x => x.Id).Select(x => new ProductPartialViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock
            }).ToList();
            ViewBag.productListPartialViewModel = new ProductListPartialViewModel() //Bu sayede home index.cshtml sayfasına gönderiyoruz
            {
                Products = products
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}