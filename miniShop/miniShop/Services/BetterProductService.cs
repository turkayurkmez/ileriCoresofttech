using miniShop.Models;

namespace miniShop.Services
{
    public class BetterProductService : IProductService
    {
        public IEnumerable<Product> GetAll()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Product A",
                    Description = "Description 1",
                    Price = 1.99m
                },
                new Product()
                {
                    Id = 2,
                    Name = "Product B",
                    Description = "Description 2",
                    Price = 2.99m
                },
                new Product()
                {
                    Id = 3,
                    Name = "Product C",
                    Description = "Description 3",
                    Price = 3.99m
                }
            };
        }
    }
}
