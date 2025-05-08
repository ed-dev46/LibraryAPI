using LibraryAPI.DTOs;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger<AuthorController> _logger;
        public AuthorController(IAuthorService authorService, ILogger<AuthorController> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            _logger.LogInformation("Fetching all authors");
            var authors = await _authorService.GetAllAuthorsAsync();
            if (authors == null || !authors.Any())
            {
                return NotFound("No authors found");
            }
            _logger.LogInformation($"Found {authors.Count} authors");
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            _logger.LogInformation($"Fetching author with ID: {id}");
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                _logger.LogWarning($"Author with ID: {id} not found");
                return NotFound();
            }
            _logger.LogInformation($"Found author: {author.Name}");
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] AuthorDTO authorDTO)
        {
            _logger.LogInformation("Adding new author");
            if (authorDTO == null)
            {
                _logger.LogWarning("Author data is null");
                return BadRequest();
            }
            var author = await _authorService.AddAuthorAsync(authorDTO);
            if (author == null)
            {
                _logger.LogWarning("Failed to add author");
                return BadRequest("Failed to add author");
            }
            _logger.LogInformation($"Author added with ID: {author.Id}");
            return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor([FromBody] AuthorDTO authorDTO, int id)
        {
            _logger.LogInformation($"Updating author with ID: {id}");
            if (authorDTO == null)
            {
                _logger.LogWarning("Author data is null");
                return BadRequest();
            }
            var author = await _authorService.UpdateAuthorAsync(authorDTO, id);
            if (author == null)
            {
                _logger.LogWarning($"Failed to update author with ID: {id}");
                return NotFound();
            }
            _logger.LogInformation($"Author updated with ID: {author.Id}");
            return Ok(author);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            _logger.LogInformation($"Deleting author with ID: {id}");
            var result = await _authorService.DeleteAuthorAsync(id);
            if (result == 0)
            {
                _logger.LogWarning($"Failed to delete author with ID: {id}");
                return NotFound();
            }
            _logger.LogInformation($"Author with ID: {id} deleted");
            return Ok($"deleted: {result}");
        }
    }
}
