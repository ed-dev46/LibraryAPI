using LibraryAPI.Models;

namespace LibraryAPI.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task<List<Book>> GetBookByAuthorIdAsync(int authorId);
        Task<Book> AddBookAsync(Book book);
        Task<int> DeleteBookAsync(int id);
        Task<Book?> UpdateBookAsync(Book book, int id);
    }
}
