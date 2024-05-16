using Domain.Entities;
using Domain.IRepository;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly TopDbContext _dbContext;

        public SubscriptionRepository(TopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Subscription?> GetSubsByGenreAsync(string tag., CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Subscription>()
                .Where(b => genre.Contains(b.Genre))
                .ToListAsync(cancellationToken);
        }

        public async Task<Book?> GetFollowersByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Book>()
                .FirstOrDefaultAsync(b => b.Title == title, cancellationToken);
        }
    }
}
