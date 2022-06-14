namespace Filters.Services
{
    public class FakeProductService : IProductService
    {
        public bool isExists(int id)
        {
            return new Random().Next(0, 2) == 0;
        }
    }
}
