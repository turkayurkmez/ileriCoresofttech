using miniShop.Models;

namespace miniShop.Services
{
    public class ProductService : IProductService
    {
        public IEnumerable<Product> GetAll()
        {
           return new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Product 1",
                    Description = "Description 1",
                    Price = 1.99m
                },
                new Product()
                {
                    Id = 2,
                    Name = "Product 2",
                    Description = "Description 2",
                    Price = 2.99m
                },
                new Product()
                {
                    Id = 3,
                    Name = "Product 3",
                    Description = "Description 3",
                    Price = 3.99m
                }
            };

        }
        
    
    }
}
