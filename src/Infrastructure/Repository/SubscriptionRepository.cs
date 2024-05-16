using Domain.Entities;
using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Subscription>> GetSubscriptionsByIdAsync(int user_id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<Subscription>()
                                   .Where(subscription => subscription.UserToId == user_id)
                                   .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Subscription>> GetFollowersByIdAsync(int user_id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Subscription>()
                                    .Where(follower => follower.FollowerId == user_id)
                                    .ToListAsync(cancellationToken);
        }

    }
}
