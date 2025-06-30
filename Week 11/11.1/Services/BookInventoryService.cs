using _11._1.Data;
using _11._1.Models;
using Microsoft.EntityFrameworkCore;

namespace _11._1.Services
{
    public class BookInventoryService
    {
        private readonly BookInventoryContext _context;

        public BookInventoryService(BookInventoryContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBookAsync(Book book)
        {
            try
            {
                if (await _context.Books.AnyAsync(b => b.ISBN == book.ISBN))
                {
                    return false; // Book already exists
                }

                book.CreatedDate = DateTime.Now;
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Book?> GetBookByISBNAsync(string isbn)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.OrderBy(b => b.Name).ToListAsync();
        }

        public async Task<List<Book>> SearchBooksAsync(string searchTerm)
        {
            return await _context.Books
                .Where(b => b.Name.Contains(searchTerm) || 
                           b.AuthorName.Contains(searchTerm) || 
                           b.ISBN.Contains(searchTerm))
                .OrderBy(b => b.Name)
                .ToListAsync();
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            try
            {
                var existingBook = await _context.Books.FindAsync(book.ISBN);
                if (existingBook == null)
                {
                    return false;
                }

                existingBook.Name = book.Name;
                existingBook.AuthorName = book.AuthorName;
                existingBook.Description = book.Description;
                existingBook.LastModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteBookAsync(string isbn)
        {
            try
            {
                var book = await _context.Books.FindAsync(isbn);
                if (book == null)
                {
                    return false;
                }

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task InitializeDatabaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }
    }
} 