using Microsoft.AspNetCore.Mvc.Filters;

namespace MyAspNetCoreApp.Web.Filters
{
    public class CustomResultFilter:ResultFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;
        public CustomResultFilter(string value, string name)
        {
            _value = value;
            _name = name;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add(_name,_value);  //responseın header'ına datayı ekledik. Bu response get işlemidir. Response'a sadece erişebiliriz, full time değiştiremeyiz. Elimizde zaten response var bunu modifiye edebiliriz, yeniden response üretemeyiz.

            base.OnResultExecuting(context);
        }
    }
}
