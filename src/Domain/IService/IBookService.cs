using Domain.DTO;
using Domain.Entities;
using Domain.IRepository;

namespace Domain.IService
{
    public interface IBookService : IService
    {
        Task<bool> EditBookByIdAsync(int id, Book updatedBook);

        Task<Book?> ShowBookByIdAsync(int id);
<<<<<<< HEAD
    }
}
=======

        Task<IEnumerable<Book>?> GetBooksByIdAsync(int id);
    }
}

>>>>>>> origin/third_block
