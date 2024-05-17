using Domain.Entities;
using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly TopDbContext _dbContext;

        public BookRepository(TopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> EditBookByIdAsync(int id, Book updatedBook, CancellationToken cancellationToken = default)
        {
            _dbContext.Update<Book>(updatedBook);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Book?> GetBookByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Book>()
               .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
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
    }
}