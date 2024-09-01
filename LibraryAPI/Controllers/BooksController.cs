using AutoMapper;
using LibraryApi.Interfaces;
using LibraryAPI.DTOs;
using LibraryAPI.Interfaces;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;


        public BooksController(IBookRepository bookRepository, IAuthorRepository authorRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _bookRepository.GetBooksAsync();
            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDto>(book));
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<BookDto>> PostBook(BookDto bookDto)
        {
            // Check if the author exists
            var author = await _authorRepository.GetAuthorByIdAsync(bookDto.AuthorId);
            if (author == null)
            {
                return BadRequest($"Author with Id {bookDto.AuthorId} does not exist.");
            }

            // Map DTO to entity
            var book = _mapper.Map<Book>(bookDto);
            book.Author = author;  // Set the Author entity

            await _bookRepository.AddBookAsync(book);

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, _mapper.Map<BookDto>(book));
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookDto bookDto)
        {
            if (id != bookDto.Id)
            {
                return BadRequest();
            }

            // Check if the author exists
            var author = await _authorRepository.GetAuthorByIdAsync(bookDto.AuthorId);
            if (author == null)
            {
                return BadRequest($"Author with Id {bookDto.AuthorId} does not exist.");
            }

            // Fetch the existing book without tracking to avoid tracking issues
            var existingBook = await _bookRepository.GetBookByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            // Map DTO to entity
            var book = _mapper.Map<Book>(bookDto);
            book.Author = author; // Set the Author entity

            // Update the book in the repository
            await _bookRepository.UpdateBookAsync(book);

            return NoContent();
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var success = await _bookRepository.DeleteBookAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
