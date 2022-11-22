using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.ViewModels
{
    public class VisitorViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
