using BookStore.Business.Dtos.Requests;
using BookStore.Business.Dtos.Responses;

namespace BookStore.Business
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponse>> GetAllBooksAsync();
        Task<BookResponse> AddBookAsync(AddBookRequest addBookRequest);
    }
}
