using BookStore.Business.Dtos.Responses;
using BookStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookResponse>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            return books.Select(x => new BookResponse
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                Price = x.Price,               
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                DiscountRate = x.DiscountRate
            });

        }
    }
}
