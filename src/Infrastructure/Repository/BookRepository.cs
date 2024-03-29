using Domain.DTO;
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

        public async Task<IEnumerable<BookDto>> GetByGenreAsync(string genre, CancellationToken cancellationToken = default)
        {
            List<BookDto> result = new List<BookDto>();
            List<Book> queryResult = await _dbContext.Set<Book>()
                .Where(b => genre.Contains(b.Genre))
                .ToListAsync(cancellationToken);

            foreach (var book in queryResult) 
            {
                result.Add(new BookDto(book));
            }
            return result;
        }
    }
}
