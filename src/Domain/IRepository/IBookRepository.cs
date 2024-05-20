using Domain.Entities;

namespace Domain.IRepository
{
    public interface IBookRepository: IRepository<Book>
    {
        Task<IEnumerable<Book>?> GetByGenreAsync(string genre, CancellationToken cancellationToken = default);

        Task<Book?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);

        Task<Book?> GetBookByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<bool> EditBookByIdAsync(int id, Book updatedBook, CancellationToken cancellationToken = default);

        Task<Book?> ShowBookByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Book>?> GetBooksByIdAsync(int Id, CancellationToken cancellationToken = default);
    }
}
