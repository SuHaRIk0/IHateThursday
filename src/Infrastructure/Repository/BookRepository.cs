using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    internal class BookRepository : IBookRepository
    {
        private readonly TopDbContext topDbContext;

        public BookRepository(TopDbContext topDbContext)
        {
            this.topDbContext = topDbContext;
        }

        public async Task<Book> AddAsync(Book book)
        {
            await topDbContext.Books.AddAsync(book);
            await topDbContext.SaveChangesAsync();
            return book;
        }

        //public async Task<IEnumerable<Book>> GetBooks()
        //{
        //    return await topDbContext.Books.ToListAsync();
        //}

        public Task<Book?> GetAsync(int id)
        {
            return topDbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Book?> UpdateAsync(Book book)
        {
            var existingBook = await topDbContext.Books.FindAsync(book.Id);

            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.AuthorName = book.AuthorName;
                existingBook.Picture = book.Picture;
                existingBook.LanguageBook = book.LanguageBook;
                existingBook.Genre = book.Genre;
                existingBook.Description = book.Description;
                existingBook.Status = book.Status;

                await topDbContext.SaveChangesAsync();

                return existingBook;
            }

            return null;
        }

        public async Task<Book?> DeleteAsync(int id)
        {
            var existingBook = await topDbContext.Books.FindAsync(id);

            if (existingBook != null)
            {
                topDbContext.Books.Remove(existingBook);
                await topDbContext.SaveChangesAsync();
                return existingBook;
            }

            return null;
        }
    }
}
