using Domain.DTO;
using Domain.Entities;

namespace Domain.IService
{
    public interface IBookTransformService: IService
    {
        Task<IEnumerable<BookDto>?> GetBookDtosAsync(IEnumerable<Book>? books);
    }
}
