using Domain.DTO;
using Domain.Entities;

namespace Domain.IService
{
<<<<<<< HEAD
    public interface IBookTransformService : IService
=======
    public interface IBookTransformService: IService
>>>>>>> origin/third_block
    {
        Task<IEnumerable<BookDto>?> GetBookDtosAsync(IEnumerable<Book>? books, CancellationToken cancellationToken);
        Task<BookDto?> GetBookDtoAsync(Book? book, CancellationToken cancellationToken);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> origin/third_block
