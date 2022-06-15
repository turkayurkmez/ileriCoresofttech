using BookStore.Business;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService bookService, ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger; 
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            //You ain't gonna need it: YAGNI
            _logger.LogInformation($"Bu get metodu, {DateTime.Now} tarihinde çalıştı...");
            var books = await _bookService.GetAllBooksAsync();
            
            _logger.LogWarning($"dönen kitap listesinde, {books.Count()} adet nesne var...");

            return Ok(books);
        }
    }
}
