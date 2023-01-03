using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyAspNetCoreApp.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Remote(action:"HasProductName",controller:"Product")]
        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz!")]
        [StringLength(50, ErrorMessage = "İsim alanına en fazla 50 karakter girilebilir!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz!")]
        [Range(1, 1000, ErrorMessage = "Fiyat alanı 1 ile 1000 arasında değer olmalıdır!")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz!")]
        [Range(1, 200, ErrorMessage = "Stok alanı 1 ile 200 arasında değer olmalıdır!")]
        public int? Stock { get; set; }

        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz!")]
        [StringLength(300, MinimumLength = 50, ErrorMessage = "Açıklama alanına 50 ile 300 arasında karakter girilebilir!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Lütfen bir renk seçiniz!")]
        public string? Color { get; set; } //? koyarak null olabilir diyoruz

        [Required(ErrorMessage = "Yayınlanma tarihi boş olamaz!")]
        public DateTime? PublishDate { get; set; } //önceden eklediğimiz veriler olduğu için null özelliğini açtık
        public bool isPublish { get; set; } //yayınlansın mı yayınlanmasın mı

        [Required(ErrorMessage = "Lütfen bir süre seçiniz!")]
        public int? Expire { get; set; }

        [ValidateNever]
        public IFormFile? Image { get; set; }

        [ValidateNever]
        public string? ImagePath { get; set; }

        [Required(ErrorMessage = "Lütfen bir kategori seçiniz!")]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
