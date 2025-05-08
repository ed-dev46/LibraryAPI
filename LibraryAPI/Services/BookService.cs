using LibraryAPI.DTOs;
using LibraryAPI.Models;
using LibraryAPI.Repository;
using LibraryAPI.ViewModels;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<BookViewModel>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            var booksViewModel = new List<BookViewModel>();
            foreach (var book in books)
            {
                booksViewModel.Add(new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    AuthorId = book.AuthorId,
                    Genre = book.Genre,
                    PublicationDate = book.PublicationDate
                });
            };
            return booksViewModel;
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            if (book == null)
            {
                return null;
            }

            return new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                Genre = book.Genre,
                PublicationDate = book.PublicationDate
            };
        }
        public async Task<List<BookViewModel>> GetBookByAuthorIdAsync(int authorId)
        {
            var books = await _bookRepository.GetBookByAuthorIdAsync(authorId);

            var booksViewModel = new List<BookViewModel>();

            foreach (var book in books)
            {
                booksViewModel.Add(new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    AuthorId = book.AuthorId,
                    Genre = book.Genre,
                    PublicationDate = book.PublicationDate
                });
            };

            return booksViewModel;
        }

        public async Task<BookViewModel> AddBookAsync(BookDTO bookDTO)
        {
            var book = new Book(){
                Title = bookDTO.Title,
                AuthorId = bookDTO.AuthorId,
                Genre = bookDTO.Genre,
                PublicationDate = bookDTO.PublicationDate
            };

            var bookAdded = await _bookRepository.AddBookAsync(book);

            return new BookViewModel()
            {
                Id = bookAdded.Id,
                Title = bookAdded.Title,
                AuthorId = bookAdded.AuthorId,
                Genre = bookAdded.Genre,
                PublicationDate = bookAdded.PublicationDate
            };
        }

        public async Task<int> DeleteBookAsync(int id)
        {
            return await _bookRepository.DeleteBookAsync(id);
        }

        public async Task<BookViewModel?> UpdateBookAsync(BookDTO bookDTO, int id)
        {
            var book = new Book()
            {
                Title = bookDTO.Title,
                AuthorId = bookDTO.AuthorId,
                Genre = bookDTO.Genre,
                PublicationDate = bookDTO.PublicationDate
            };

            var bookUpdated = await _bookRepository.UpdateBookAsync(book, id);

            if (bookUpdated == null)
            {
                return null;
            }

            return new BookViewModel()
            {
                Id = bookUpdated.Id,
                Title = bookUpdated.Title,
                AuthorId = bookUpdated.AuthorId,
                Genre = bookUpdated.Genre,
                PublicationDate = bookUpdated.PublicationDate
            };
        }
    }
}
