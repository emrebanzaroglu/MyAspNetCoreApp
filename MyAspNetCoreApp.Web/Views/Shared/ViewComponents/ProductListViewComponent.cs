using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Views.Shared.ViewComponents
{
    //[ViewComponent(Name ="p-list")]  vc:p-list olarak kullanmamızı sağlar. Component etiketinin ismini değiştirir.
    public class ProductListViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int type=1)
        {
            var viewmodels = _context.Product.Select(x => new ProductListComponentViewModel()
            {
                Name = x.Name,
                Description = x.Description
            }).ToList();
            if (type==1)
            {
                return View("Default",viewmodels);
                //return View(viewmodels); //herhangi bir cshtml belirtmezsek components folder'ındaki ilgili folderda cshtml dosyası arayacak ve oraya atacak.
            }
            else
            {
                return View("Type2", viewmodels);
            }
            
        }
    }
}
