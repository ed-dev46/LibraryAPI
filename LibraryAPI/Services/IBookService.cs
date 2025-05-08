using LibraryAPI.DTOs;
using LibraryAPI.ViewModels;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        Task<List<BookViewModel>> GetAllBooksAsync();
        Task<BookViewModel?> GetBookByIdAsync(int id);
        Task<List<BookViewModel>> GetBookByAuthorIdAsync(int authorId);
        Task<BookViewModel> AddBookAsync(BookDTO bookDTO);
        Task<int> DeleteBookAsync(int id);
        Task<BookViewModel?> UpdateBookAsync(BookDTO book, int id);
    }
}
