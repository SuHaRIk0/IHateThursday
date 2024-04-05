using Domain.Entities;

namespace Domain.IRepository
{
    public interface IBookRepository: IRepository<Book>
    {
        Task<IEnumerable<Book>?> GetByGenreAsync(string genre, CancellationToken cancellationToken = default);
        Task<Book?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);

    }
}
