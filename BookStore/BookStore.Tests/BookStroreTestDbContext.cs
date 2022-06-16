using BookStore.DataAccess.Data;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Tests
{
    public class BookStroreTestDbContext : BookStoreDbContext
    {
        public BookStroreTestDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            seedDataWithJsonFile<Book>(modelBuilder, "../../../Data/books.json");
        }

        void seedDataWithJsonFile<T>(ModelBuilder modelBuilder, string jsonFilePath) where T:class, IEntity
        {
            var json = System.IO.File.ReadAllText(jsonFilePath);
            var data = JsonConvert.DeserializeObject<List<T>>(json);
            modelBuilder.Entity<T>().HasData(data);
        }
    }
}
