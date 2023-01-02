using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Filters;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;
using System.Diagnostics;

namespace MyAspNetCoreApp.Web.Controllers
{
    [LogFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        // Ancak bu route'lardan sonra diğer sayfalara gidemem o yüzden home controllerın üstünde default vir ontroller tanımlamam gerekir
        [Route("")]  //üçü de aynı sonucu verir. Boş bırakılınca bu metot çalışsın demek
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
          {
            ProductListPartialViewModelMethod();
            return View();
        }


        [CustomExceptionFilter]
        public IActionResult Privacy()
        {
            //throw new Exception("Veritabanı ile ilgili bir hata meydana geldi.");
            ProductListPartialViewModelMethod();
            return View();
        }

        public IActionResult Visitor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveVisitorComment(VisitorViewModel visitorViewModel)
        {
            try
            {
                var visitor = _mapper.Map<Visitors>(visitorViewModel);
                visitor.Created = DateTime.Now;
                _context.Visitors.Add(visitor);
                _context.SaveChanges();
                TempData["result"] = "Yorum kaydedilmiştir.";
                return RedirectToAction("Visitor");
            }
            catch (Exception)
            {
                TempData["result"] = "Yorum kaydedilirken bir hata meydana geldi.";
                return RedirectToAction("Visitor");
            }
            
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
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            errorViewModel.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View(errorViewModel);
        }
    }
}