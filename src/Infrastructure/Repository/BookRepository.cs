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
        private readonly TopDbContext _dbContext;

        public BookRepository(TopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> EditBookByIdAsync(int id, Book updatedBook, CancellationToken cancellationToken = default)
        {
            _dbContext.Update<Book>(updatedBook);

            var newBookState = new BookState { Id = id, StateBook = updatedBook.Status };

            _dbContext.Update<BookState>(newBookState);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Book?> GetBookByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Book>()
               .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }
        
        public async Task<IEnumerable<Book>?> GetBooksByIdAsync(int Id, CancellationToken cancellationToken = default)
        {
            var boo = await _dbContext.Set<BookState>()
                .Where(book => book.UserId == Id)
                .ToListAsync(cancellationToken);
            var books = new List<Book>();
            foreach (var dummy in boo)
            {
                books.Add(await _dbContext.Set<Book>()
                    .Where(book => book.Id == dummy.BookId)
                    .FirstOrDefaultAsync(cancellationToken));
            }
            return books;
        }

        public async Task<IEnumerable<Book>?> GetByGenreAsync(string genre, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Book>()
                .Where(b => genre.Contains(b.Genre))
                .ToListAsync(cancellationToken);
        }

        public async Task<Book?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Book>()
                .FirstOrDefaultAsync(b => b.Title == title, cancellationToken);
        }

        public Task<Book?> ShowBookByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<Book>> GetBooksByIdAsync(int Id)
        //{
        //    var books = await _dbContext.Books
        //        .Where(book => book.Id == Id)
        //        .ToListAsync();

        //    return books;
        //}

        

        // SOME NEW CODE

        public async Task<bool> AddAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        //public async Task<IEnumerable<Book>> GetBooks()
        //{
        //    return await topDbContext.Books.ToListAsync();
        //}

        //public Task<Book?> GetAsync(int id)
        //{
        //    return _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        //}


        //public async Task<Book?> UpdateAsync(Book book)
        //{
        //    var existingBook = await _dbContext.Books.FindAsync(book.Id);

        //    if (existingBook != null)
        //    {
        //        existingBook.Title = book.Title;
        //        existingBook.AuthorName = book.AuthorName;
        //        existingBook.Picture = book.Picture;
        //        existingBook.LanguageBook = book.LanguageBook;
        //        existingBook.Genre = book.Genre;
        //        existingBook.Description = book.Description;
        //        existingBook.Status = book.Status;

        //        await _dbContext.SaveChangesAsync();

        //        return existingBook;
        //    }

        //    return null;
        //}

        public async Task<Book?> DeleteAsync(int id)
        {
            var existingBook = await _dbContext.Books.FindAsync(id);

            if (existingBook != null)
            {
                _dbContext.Books.Remove(existingBook);
                await _dbContext.SaveChangesAsync();
                return existingBook;
            }

            return null;
        }
    }
}
