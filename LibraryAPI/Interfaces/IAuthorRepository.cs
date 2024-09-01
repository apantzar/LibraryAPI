using LibraryAPI.Models;

namespace LibraryApi.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> AddAuthorAsync(Author author);
        Task<Author> UpdateAuthorAsync(Author author);
        Task<bool> DeleteAuthorAsync(int id);
    }
}
