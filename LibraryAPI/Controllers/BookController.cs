using LibraryAPI.DTOs;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _logger;
        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            _logger.LogInformation("Fetching all books");
            var books = await _bookService.GetAllBooksAsync();
            if (books == null || !books.Any())
            {
                _logger.LogWarning("No books found");
                return NotFound("No books found");
            }
            _logger.LogInformation($"Found {books.Count} books");
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            _logger.LogInformation($"Fetching book with ID: {id}");
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                _logger.LogWarning($"Book with ID: {id} not found");
                return NotFound();
            }
            _logger.LogInformation($"Found book: {book.Title}");
            return Ok(book);
        }

        [HttpGet("author/{authorId}")]
        public async Task<IActionResult> GetBookByAuthorId(int authorId)
        {
            _logger.LogInformation($"Fetching books by author ID: {authorId}");
            var books = await _bookService.GetBookByAuthorIdAsync(authorId);
            if (books == null || !books.Any())
            {
                _logger.LogWarning($"No books found for author ID: {authorId}");
                return NotFound("No books found for this author");
            }
            _logger.LogInformation($"Found {books.Count} books for author ID: {authorId}");
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookDTO bookDTO)
        {
            _logger.LogInformation("Adding new book");
            if (bookDTO == null)
            {
                _logger.LogWarning("Book data is null");
                return BadRequest();
            }
            var book = await _bookService.AddBookAsync(bookDTO);
            if (book == null)
            {
                _logger.LogWarning("Failed to add book");
                return BadRequest("Failed to add book");
            }
            _logger.LogInformation($"Book added with ID: {book.Id}");
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookDTO bookDTO, int id)
        {
            _logger.LogInformation($"Updating book with ID: {id}");
            if (bookDTO == null)
            {
                _logger.LogWarning("Book data is null");
                return BadRequest();
            }
            var book = await _bookService.UpdateBookAsync(bookDTO, id);
            if (book == null)
            {
                _logger.LogWarning($"Failed to update book with ID: {id}");
                return NotFound();
            }
            _logger.LogInformation($"Book updated with ID: {book.Id}");
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            _logger.LogInformation($"Deleting book with ID: {id}");
            var result = await _bookService.DeleteBookAsync(id);
            if (result == 0)
            {
                _logger.LogWarning($"Failed to delete book with ID: {id}");
                return NotFound();
            }
            _logger.LogInformation($"Book with ID: {id} deleted successfully");
            return NoContent();
        }
    }
}
