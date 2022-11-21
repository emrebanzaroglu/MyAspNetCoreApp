using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Views.Shared.ViewComponents
{
    public class ProductListViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewmodels = _context.Product.Select(x => new ProductListComponentViewModel()
            {
                Name = x.Name,
                Description = x.Description
            }).ToList();
            return View(viewmodels); //herhangi bir cshtml belirtmezsek components folder'ındaki iligli folderda cshtml dosyası arayacak ve oraya atacak.
        }
    }
}
