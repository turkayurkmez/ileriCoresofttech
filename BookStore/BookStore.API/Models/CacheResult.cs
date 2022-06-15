using BookStore.Business.Dtos.Responses;

namespace BookStore.API.Models
{
    public class CacheResult
    {
        public IEnumerable<BookResponse> BookResponses { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
