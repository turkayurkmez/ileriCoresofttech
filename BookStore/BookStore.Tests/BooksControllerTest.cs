using BookStore.Business.Dtos.Requests;
using BookStore.Business.Dtos.Responses;
using BookStore.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace BookStore.Tests
{
    public class BooksControllerTest : IClassFixture<InMemoryWebAppFactory<Program>>
    {
        private readonly InMemoryWebAppFactory<Program> _factory;
        public BooksControllerTest(InMemoryWebAppFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void Test1()
        {
            var client = _factory.CreateClient();
            var response = client.GetAsync("/api/books").Result;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public void Get_books_from_api()
        {
            var client = _factory.CreateClient();
            var response = client.GetAsync("/api/books").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var list = JsonConvert.DeserializeObject<List<BookResponse>>(content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void Post_book_to_api()
        {
            var client = _factory.CreateClient();
            var book = new AddBookRequest
            {
                Title = "Test Book",
                Author = "Test Author",
                Price = 10.0m,
                Description = "Test Description",
                ImageUrl = "Test ImageUrl",
                DiscountRate = 0.15
            };
            var content = JsonConvert.SerializeObject(book);
            var response = client.PostAsync("/api/books", new StringContent(content, Encoding.UTF8, "application/json")).Result;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}