using Domain.DTO;
using Domain.Entities;

namespace Domain.IService
{
    public interface IBookTransformService: IService
    {
        Task<IEnumerable<BookDto>?> GetBookDtosAsync(IEnumerable<Book>? books, CancellationToken cancellationToken);
        Task<BookDto?> GetBookDtoAsync(Book? book, CancellationToken cancellationToken);
    }
}
