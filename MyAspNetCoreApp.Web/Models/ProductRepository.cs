using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>() //static yapmamızın nedeni uygulama kapanıncaya kadar memoryde olsun sonra kaybolsun diye
        {
            new Product { Id = 1, Name = "Kalem", Price = 10, Stock = 50 },
            new Product { Id = 2, Name = "Silgi", Price = 8, Stock = 100 },
            new Product { Id = 3, Name = "Cetvel", Price = 20, Stock = 20 },
            new Product { Id = 4, Name = "Uç", Price = 5, Stock = 200 }
        };
        public List<Product> GetAll()
        {
            return _products;
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }
        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == id);
            if (hasProduct != null)
            {
                _products.Remove(hasProduct);
            }
            else throw new Exception($"Bu id({id})'ye sahip ürün bulunmamaktadır.");
        }
        public void Update(Product product)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == product.Id);
            if (hasProduct != null)
            {
                hasProduct.Name = product.Name;
                hasProduct.Price = product.Price;
                hasProduct.Stock = product.Stock;
                var index = _products.FindIndex(x => x.Id == product.Id);
                _products[index] = hasProduct; //productslardan x indexine sahip ürünü hasproducts ile güncelle demek.
            }
            else throw new Exception($"Bu id({product.Id})'ye sahip ürün bulunmamaktadır.");
        }
    }
}
