using Domain.DTO;
using Domain.Entities;

namespace Domain.IRepository
{
    public interface IBookRepository: IRepository<Book>
    {
        Task<IEnumerable<BookDto>> GetByGenreAsync(string genre, CancellationToken cancellationToken = default);
    }
}
