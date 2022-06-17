using BookStore.Business.Dtos.Requests;
using BookStore.Business.Dtos.Responses;
using BookStore.DataAccess.Repositories;
using BookStore.Entities;
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

        public async Task<BookResponse> AddBookAsync(AddBookRequest addBookRequest)
        {
            var book = new Book
            {
                Title = addBookRequest.Title,
                Author = addBookRequest.Author,
                Description = addBookRequest.Description,
                ImageUrl = addBookRequest.ImageUrl,
                Price = addBookRequest.Price,
                DiscountRate = addBookRequest.DiscountRate,
                Stock = addBookRequest.Stock,
                IsActive = true,
                CreatedDate = DateTime.Now
            };

           await _bookRepository.AddAsync(book);

            return new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                ImageUrl = book.ImageUrl,
                Price = book.Price,
                DiscountRate = book.DiscountRate               
            };




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
