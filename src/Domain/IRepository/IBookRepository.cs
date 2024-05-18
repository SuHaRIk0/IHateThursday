using Domain.Entities;

namespace Domain.IRepository
{
<<<<<<< HEAD
    public interface IBookRepository : IRepository<Book>
=======
    public interface IBookRepository: IRepository<Book>
>>>>>>> origin/third_block
    {
        Task<IEnumerable<Book>?> GetByGenreAsync(string genre, CancellationToken cancellationToken = default);
        Task<Book?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
        Task<Book?> GetBookByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> EditBookByIdAsync(int id, Book updatedBook, CancellationToken cancellationToken = default);
        Task<Book?> ShowBookByIdAsync(int id, CancellationToken cancellationToken = default);
<<<<<<< HEAD

    }
}
=======
        //Task<List<Book>> GetBooksByIdAsync(int Id);

        Task<IEnumerable<Book>?> GetBooksByIdAsync(int Id, CancellationToken cancellationToken = default);
    }
}
>>>>>>> origin/third_block
