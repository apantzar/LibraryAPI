using LibraryApi.Interfaces;
using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;

        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _context.Authors.Include(a => a.Books).ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _context.Authors.Include(a => a.Books)
                                         .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return false;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
