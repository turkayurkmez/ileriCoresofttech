using BookStore.Business.Dtos.Responses;
using BookStore.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
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
        
    }
}