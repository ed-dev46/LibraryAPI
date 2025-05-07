using LibraryAPI.Models;

namespace LibraryAPI.Repository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthorsAsync();
        Task<Author?> GetAuthorByIdAsync(int id);
        Task<Author> AddAuthorAsync(Author author);
        Task<int> DeleteAuthorAsync(int id);
        Task<Author?> UpdateAuthorAsync(Author author, int id);
    }
}
