using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;
        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            var authors = await _context.Authors.ToListAsync();
            return authors;
        }

        public async Task<Author?> GetAuthorByIdAsync(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
            return author;
        }
        public async Task<Author> AddAuthorAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }
       
        public async Task<int> DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
            }
            return await _context.SaveChangesAsync();
        }
        public async Task<Author?> UpdateAuthorAsync(Author author, int id)
        {
            if (_context.Authors.Any(x => x.Id == id))
            {
                author.Id = id;
                _context.Authors.Update(author);
                await _context.SaveChangesAsync();
                return await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
            }
            return null;
        }
    }
}
