using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IBookRepository
    {
        //Task<IEnumerable<Book>> GetBooks();

        Task<Book?> GetAsync(int id);

        Task<Book> AddAsync(Book book);

        Task<Book?> UpdateAsync(Book book);

        Task<Book?> DeleteAsync(int id);
    }
}
