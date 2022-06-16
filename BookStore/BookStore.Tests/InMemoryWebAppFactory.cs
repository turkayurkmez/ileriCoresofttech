using BookStore.DataAccess.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Tests
{
    public class InMemoryWebAppFactory<T> : WebApplicationFactory<T> where T : class
    {


        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing")
                   .ConfigureTestServices(services => {
                       var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase("inMemory").Options;
                       services.AddScoped<BookStoreDbContext>(provider => new BookStroreTestDbContext(options));
                       
                       var db = services.BuildServiceProvider().CreateScope().ServiceProvider.GetRequiredService<BookStoreDbContext>();
                       db.Database.EnsureCreated();
                   });
        }
    }


}
