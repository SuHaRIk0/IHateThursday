using Domain.DTO;
using Domain.Entities;

namespace Domain.IService
{
    public interface IBookTransformService
    {
        Task<IEnumerable<BookDto>?> GetBookDtosAsync(IEnumerable<Book>? books);
    }
}
