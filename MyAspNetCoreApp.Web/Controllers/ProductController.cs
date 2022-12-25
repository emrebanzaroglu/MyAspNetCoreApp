using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAspNetCoreApp.Web.Filters;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Controllers
{
    
    public class ProductController : Controller
    {
        private AppDbContext _context;
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(AppDbContext context, IMapper mapper)
        {
            _productRepository = new ProductRepository();
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var product = _context.Product.ToList();
            return View(_mapper.Map<List<ProductViewModel>>(product));
        }

        //[HttpGet("{page}/{pagesize}")]  //alttakiyle aynı şey sadece name belirtmiyoruz
        [Route("[controller]/[action]/Pages/{page}/{pagesize}",Name ="productpage")]
        public IActionResult Pages(int page,int pageSize)
        {

            //page=1 pagesize=3 => ilk 3 kayıt
            //page=2 pagesize=3 => ikinci 3 kayıt
            var products = _context.Product.Skip((page-1)*pageSize).Take(pageSize).ToList(); //skip metodu atlama işlemi yapar. page'den 1 çıkartıp pagesize ile çarpıp o kadar datayı atlar. Take fonksiyonu içine kaç yazılırsa skip fonksiyonunda atalaycağı kadarını atlar ve içerisindeki kadar alır.

            ViewBag.page = page;
            ViewBag.pageSize = pageSize;

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }


        [Route("urunler/urun/{productid}",Name ="product")]  //controller ve action yazmak şart değil olmasa da olur ayrıca metod ismini de farklı verebiliyoruz
        [ServiceFilter(typeof(NotFoundFilter))]  // NotFoundFilter ctor'da parametre aldığı için servicefilter olarak eklenir. Servicefilter eklendiği zaman DI container'a bu filter eklenmeli.
        public IActionResult GetById(int productid) //program.cs 'de route metodunda id kullanıldığı için id yazmamız gerekiyor
        {
            var products = _context.Product.Find(productid);
            return View(_mapper.Map<ProductViewModel>(products)); //products'ı ProductViewModel'e çevir
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
            }, "Value", "Data"); //önce value sonra kullanıcının göreceği kısım
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel newProduct)
        {
            //if (!string.IsNullOrEmpty(newProduct.Name) && (newProduct.Name.StartsWith("A") || newProduct.Name.StartsWith("a")))  //A harfi ile başlıyorsa
            //{
            //    ModelState.AddModelError(string.Empty, "Ürün ismi A , a harfi ile başlayamaz."); //string.Empty diyince sayfanın başına koyar hata mesajını. Eğer textbox'ın altına koymak istersen ilgili textbox'ın adını yazmak gerekir.
            //}

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
            }, "Value", "Data"); //önce value sonra kullanıcının göreceği kısım

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Product.Add(_mapper.Map<Product>(newProduct)); //ProductViewModel'i Product'a mapleyecek
                    _context.SaveChanges();
                    TempData["status"] = "Ürün başarıyla eklendi.";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "Ürün kaydedilirken bir hata meydana geldi. Lütfen daha sonra tekrar deneyiniz.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Update(int id)
        {
            var product = _context.Product.Find(id);


            ViewBag.ExpireValue = product.Expire;
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
            }, "Value", "Data", product.Color); //önce value sonra kullanıcının göreceği kısım ve seçili olanı göstereceği kısım
            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel updateProduct)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ExpireValue = updateProduct.Expire;
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
            }, "Value", "Data", updateProduct.Color);
                return View();
            }
            _context.Product.Update(_mapper.Map<Product>(updateProduct)); //ProductViewModel'i Product'a dönüştürdük.
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        //[HttpGet("{id}")] //genel route yapısı kullandığım için ?id şeklinde gözüküyordu ancak şimdi /id olarak gözükecek
        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Remove(int id)
        {
            var product = _context.Product.Find(id);

            _context.Product.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [AcceptVerbs("GET", "POST")]  //get te olabilir post ta olabilir demek
        public IActionResult HasProductName(string Name)
        {
            var anyProduct = _context.Product.Any(x => x.Name.ToLower() == Name.ToLower()); //ürün isminden db de var mı?
            if (anyProduct) //anyPRoduct true ise
            {
                return Json("Kaydetmeye çalıştığınız ürün ismi veritabanında bulunmaktadır!"); //hata mesajı döndür
            }
            else // yoksa
            {
                return Json(true); //validasyondan geç
            }
        }
    }
}
