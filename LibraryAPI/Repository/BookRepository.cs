using LibraryAPI.Models;
using LibraryAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;
        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            return book;
        }

        public async Task<List<Book>> GetBookByAuthorIdAsync(int authorId)
        {
            var books = await _context.Books.Where(x => x.AuthorId == authorId).ToListAsync();
            return books;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<int> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<Book?> UpdateBookAsync(Book book, int id)
        {
            if (_context.Books.Any(x => x.Id == id))
            {
                book.Id = id;
                _context.Books.Update(book);
                await _context.SaveChangesAsync();
                return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            }
            return null;
        }
    }
}
