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
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            var authors = await _authorRepository.GetAuthorsAsync();
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authors));
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDto>(author));
        }

        // POST: api/Authors
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> PostAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            await _authorRepository.AddAuthorAsync(author);
            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, _mapper.Map<AuthorDto>(author));
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorDto authorDto)
        {
            if (id != authorDto.Id)
            {
                return BadRequest();
            }

            var author = _mapper.Map<Author>(authorDto);
            await _authorRepository.UpdateAuthorAsync(author);

            return NoContent();
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var success = await _authorRepository.DeleteAuthorAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
