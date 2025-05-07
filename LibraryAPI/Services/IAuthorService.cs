using LibraryAPI.DTOs;
using LibraryAPI.ViewModels;

namespace LibraryAPI.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorViewModel>> GetAllAuthorsAsync();
        Task<AuthorViewModel?> GetAuthorByIdAsync(int id);
        Task<AuthorViewModel> AddAuthorAsync(AuthorDTO authorDTO);
        Task<int> DeleteAuthorAsync(int id);
        Task<AuthorViewModel?> UpdateAuthorAsync(AuthorDTO authorDTO, int id);
    }
}
