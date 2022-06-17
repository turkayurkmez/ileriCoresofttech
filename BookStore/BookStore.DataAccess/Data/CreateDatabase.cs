using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Data
{
    public static class CreateDatabase
    {
        public static void Create(BookStoreDbContext context)
        {
            
            var connectionString = context.Database.GetConnectionString();
            context.Database.Migrate();

            if (context.Books.Any())
            {
                return;
            }

            var books = new List<Book>();
            books.Add(new Book
            {
                Title = "The Lord of the Rings",
                Author = "J.R.R. Tolkien",
                Description = "The Lord of the Rings is an epic high fantasy novel written by English author J. R. R. Tolkien. The story began as a sequel to Tolkien's 1937 fantasy novel The Hobbit, but eventually developed into a much larger work. Written in stages between 1937 and 1949, The Lord of the Rings is one of the best-selling novels ever written, with over 150 million copies sold.",
                Price = 12.99m,

                ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51Zr-t%2B7z%2BL._SX331_BO1,204,203,200_.jpg"


            });

            context.Books.AddRange(books);
            context.SaveChanges();

        }
    }
}
