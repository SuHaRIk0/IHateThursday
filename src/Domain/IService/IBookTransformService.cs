using Domain.DTO;
using Domain.Entities;

namespace Domain.IService
{
    public interface IBookTransformService: IService
    {
        Task<IEnumerable<BookDto>?> GetBookDtosAsync(IEnumerable<Book>? books, CancellationToken cancellationToken);
        Task<BookDto?> GetBookDtosAsync(Book? book, CancellationToken cancellationToken);
    }
}
