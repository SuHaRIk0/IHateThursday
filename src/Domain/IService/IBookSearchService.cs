using Domain.Entities;

namespace Domain.IService
{
    public interface IBookSearchService
    {
        Task<Book?> GetByTitleAsync(string title, CancellationToken cancellationToken);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> origin/third_block
