using LibraryAPI.DTOs;
using LibraryAPI.Models;
using LibraryAPI.Repository;
using LibraryAPI.ViewModels;

namespace LibraryAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<AuthorViewModel>> GetAllAuthorsAsync()
        {
            var authors = await _authorRepository.GetAllAuthorsAsync();
            var authorsViewModel = new List<AuthorViewModel>();
            foreach (var x in authors)
            {
                authorsViewModel.Add(new AuthorViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    DateOfBirth = x.DateOfBirth,
                    Nationality = x.Nationality
                });
            }
            return authorsViewModel;
        }

        public async Task<AuthorViewModel?> GetAuthorByIdAsync(int id)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(id);

            if (author == null)
            {
                return null;
            }

            return new AuthorViewModel() {
                Id = author.Id,
                Name = author.Name,
                DateOfBirth = author.DateOfBirth,
                Nationality = author.Nationality
            };
        }

        public async Task<AuthorViewModel> AddAuthorAsync(AuthorDTO authorDTO)
        {
            var author = new Author()
            {
                Name = authorDTO.Name,
                DateOfBirth = authorDTO.DateOfBirth,
                Nationality = authorDTO.Nationality
            };

            var authorAdded = await _authorRepository.AddAuthorAsync(author);

            return new AuthorViewModel()
            {
                Id = authorAdded.Id,
                Name = authorAdded.Name,
                DateOfBirth = authorAdded.DateOfBirth,
                Nationality = authorAdded.Nationality
            };
        }

        public async Task<int> DeleteAuthorAsync(int id)
        {
            return await _authorRepository.DeleteAuthorAsync(id);
        }

        public async Task<AuthorViewModel?> UpdateAuthorAsync(AuthorDTO authorDTO, int id)
        {
            var author = new Author()
            {
                Name = authorDTO.Name,
                DateOfBirth = authorDTO.DateOfBirth,
                Nationality = authorDTO.Nationality
            };

            var authorUpdated = await _authorRepository.UpdateAuthorAsync(author, id);

            if (authorUpdated == null)
            {
                return null;
            }

            return new AuthorViewModel()
            {
                Id = authorUpdated.Id,
                Name = authorUpdated.Name,
                DateOfBirth = authorUpdated.DateOfBirth,
                Nationality = authorUpdated.Nationality
            };

        }
    }
}
