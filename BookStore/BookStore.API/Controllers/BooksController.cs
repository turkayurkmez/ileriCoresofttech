using BookStore.API.Models;
using BookStore.Business;
using BookStore.Business.Dtos.Requests;
using BookStore.Business.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Text;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;
        private readonly IMemoryCache _memoryCache;
       // private readonly IDistributedCache _distributedCache;
        private object OnEviction;

  

        public BooksController(IBookService bookService,
                               ILogger<BooksController> logger,
                               IMemoryCache memCache


                               )// IDistributedCache distributedCache
        {
            _bookService = bookService;
            _logger = logger;
            _memoryCache = memCache;
            //_distributedCache = distributedCache;
        }

        [HttpGet]
        //[OutputCache(duration=60, Vary="id")]
        [ResponseCache(Duration = 120, VaryByHeader = "User-Agent")]
        public async Task<IActionResult> GetBooks()
        {
            //You ain't gonna need it: YAGNI
            _logger.LogInformation($"Bu get metodu, {DateTime.Now} tarihinde çalıştı...");
            var books = await _bookService.GetAllBooksAsync();

            _logger.LogWarning($"dönen kitap listesinde, {books.Count()} adet nesne var...");
            return Ok(books);
        }

        [HttpGet("InMemory")]
        public async Task<IActionResult> GetBooksWithMemory()
        {
            //Book koleksiyonuna her ihtiyaç duyduğumda; service'den çekmek yerine; bellekteki datayı kullanmak istiyorum (API'nin herhangi bir yerinden bu bellekteki alana erişebilmeliyim)

            //if (!_memoryCache.TryGetValue("booksInMemo", out CacheResult booksInMemory))
            //{
            //    var books = await _bookService.GetAllBooksAsync();
            //    booksInMemory = new CacheResult();
            //    booksInMemory.CreatedDate = DateTime.Now;
            //    booksInMemory.BookResponses = books;
            //    _memoryCache.Set("booksInMemo", booksInMemory);

            //}            

            var result = await _memoryCache.GetOrCreateAsync<CacheResult>("booksInMemo", async (entry) =>
              {
                  entry.SlidingExpiration = TimeSpan.FromMinutes(5);
                  entry.Priority = CacheItemPriority.Normal;


                  PostEvictionCallbackRegistration OnEviction = new PostEvictionCallbackRegistration();
                  OnEviction.EvictionCallback = new PostEvictionDelegate((key, value, reason, state) =>
                  {
                      _logger.LogInformation($"{key} keyli nesne silindi. {reason} sebebi ile...");

                  });

                  entry.PostEvictionCallbacks.Add(OnEviction);
                // entry.RegisterPostEvictionCallback()




                  CacheResult cacheResult = new CacheResult
                  {
                      CreatedDate = DateTime.Now,
                      BookResponses = await _bookService.GetAllBooksAsync()
                  };
                //booksInMemory.BookResponses = await _bookService.GetAllBooksAsync();

                  return cacheResult;
              });


            return Ok(result);


        }

        [HttpGet("FromMemory")]
        public async Task<IActionResult> GetBooksFromMemory()
        {
            if (_memoryCache.TryGetValue("booksInMemo", out CacheResult booksInMemory))
            {
                return Ok(booksInMemory);
            }



            return Ok(new { Message = "Bellekte hiç kitap yok..." });
        }

        [HttpGet("FromDistributedCache")]
        public async Task<IActionResult> GetBooksFromDistributedCache()
        {
            ////  var books = _distributedCache.Get("booksInDistributedCache");
            //  //_distributedCache.
            //  if (books != null)
            //  {
            //      string message = Encoding.UTF8.GetString(books);
            //      var response = JsonConvert.DeserializeObject<IEnumerable<BookResponse>>(message);
            //      return Ok(response);
            //  }
            //  else
            //  {
            //      var booksFromService = await _bookService.GetAllBooksAsync();
            //      var booksAsJson = JsonConvert.SerializeObject(booksFromService);
            //      var booksAsBytes = Encoding.UTF8.GetBytes(booksAsJson);
            //      _distributedCache.Set("booksInDistributedCache", booksAsBytes);

            //      return Ok(booksFromService);

            //  }

            return Ok();

          


        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookRequest addBookRequest)
        {
            if (ModelState.IsValid)
            {
                BookResponse book = await _bookService.AddBookAsync(addBookRequest);                
                return Ok(book);
            }
            return BadRequest(ModelState);
        }

    }
}
