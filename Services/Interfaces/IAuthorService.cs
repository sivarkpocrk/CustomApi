using System.Collections.Generic;
using System.Threading.Tasks;
using CustomApi.Models;

namespace CustomApi.Services.Interfaces
{

    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task AddAuthorAsync(Author author);
        Task<bool> UpdateAuthorAsync(int id, Author author);
        Task<bool> DeleteAuthorAsync(int id);
    }

}

