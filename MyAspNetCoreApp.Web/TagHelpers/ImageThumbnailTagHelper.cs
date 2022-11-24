using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyAspNetCoreApp.Web.TagHelpers
{
    [HtmlTargetElement("thumbnail")]
    public class ImageThumbnailTagHelper:TagHelper
    {
        public string ImageSrc { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName= "img";
            string fileName = ImageSrc.Split(".")[0]; //noktaya göre 2 parçaya böler ve ilk parçayı alırız.
            string fileExtensions = Path.GetExtension(ImageSrc); //.jpg verir. uzantıyı alırız.
            output.Attributes.SetAttribute("src", $"{fileName}-100x100{fileExtensions}"); //resmin adını depiştirir.
        }
    }
}
