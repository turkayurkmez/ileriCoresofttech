using BookStore.Business.Dtos.Responses;

namespace BookStore.Business
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponse>> GetAllBooksAsync();
    }
}
