using BookStore.DataAccess.Data;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    public class EFBookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _context;

        public EFBookRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Book entity)
        {
            await _context.Books.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Books.FindAsync(id);
            _context.Books.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();

        }

        public async Task<Book> GetAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task UpdateAsync(Book entity)
        {
            _context.Books.Update(entity);
            await _context.SaveChangesAsync();

        }
    }
}
