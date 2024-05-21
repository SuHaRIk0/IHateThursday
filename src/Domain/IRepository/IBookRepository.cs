using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>?> GetByGenreAsync(string genre, CancellationToken cancellationToken = default);
        Task<Book?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
        Task<Book?> GetBookByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> EditBookByIdAsync(int id, Book updatedBook, CancellationToken cancellationToken = default);
        Task<Book?> ShowBookByIdAsync(int id, CancellationToken cancellationToken = default);
        //Task<List<Book>> GetBooksByIdAsync(int Id);

        Task<IEnumerable<Book>?> GetBooksByIdAsync(int Id, CancellationToken cancellationToken = default);
        //Task<IEnumerable<Book>> GetBooks();

        //Task<Book?> GetAsync(int id);

        Task<bool> AddAsync(Book book);

        //Task<Book?> UpdateAsync(Book book);

        Task<Book?> DeleteAsync(int id);
    }
}
