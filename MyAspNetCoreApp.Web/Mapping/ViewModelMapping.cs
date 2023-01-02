using AutoMapper;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Mapping
{
    public class ViewModelMapping:Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Product,ProductViewModel>().ReverseMap();  //product entity'sini ProductViewModel'e mapler. 
                                                                 //reversemap ile tam terisini de yapabilir.

            CreateMap<Product, ProductUpdateViewModel>().ReverseMap();  //product entity'sini ProductViewModel'e mapler. 

            CreateMap<Visitors, VisitorViewModel>().ReverseMap();
        }
    }
}
