namespace MyAspNetCoreApp.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string? Color { get; set; } //? koyarak null olabilir diyoruz
        public DateTime? PublishDate { get; set; } //önceden eklediğimiz veriler olduğu için null özelliğini açtık
        public bool isPublish { get; set; } //yayınlansın mı yayınlanmasın mı
        public int Expire { get; set; }
    }
}
