using miniShop.Models;

namespace miniShop.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
       
    }
}
