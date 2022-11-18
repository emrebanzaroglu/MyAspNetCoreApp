using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;
        private readonly ProductRepository _productRepository;
        public ProductController(AppDbContext context)
        {
            _productRepository = new ProductRepository();
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Product.ToList());
        }
        public IActionResult Remove(int id)
        {
            var product = _context.Product.Find(id);
            _context.Product.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1 },
                {"3 Ay",3 },
                {"6 Ay",6 },
                {"12 Ay",12 }
            };
            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {
                new(){Data="Mavi",Value="Mavi"},
                new(){Data="Kırmızı",Value="Kırmızı"},
                new(){Data="Yeşil",Value="Yeşil"},
                new(){Data="Sarı",Value="Sarı"}
            },"Value","Data"); //önce value sonra kullanıcının göreceği kısım
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product newProduct)
        {
            _context.Product.Add(newProduct);
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Product.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product updateProduct)
        {
            _context.Product.Update(updateProduct);
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla güncellendi.";
            return RedirectToAction("Index");
        }
    }
}
