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
    }
}