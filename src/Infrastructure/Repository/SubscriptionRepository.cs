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

        public async Task<Subscription?> GetSubscriptionByIdAsync(int followerId, int userToId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Subscription>()
               .FirstOrDefaultAsync(u => u.UserToId == userToId && u.FollowerId == followerId, cancellationToken);
        }


        public async Task<IEnumerable<string>> GetSubscriptionsByIdAsync(int user_id, CancellationToken cancellationToken = default)
        {
            var subscriptionIds = await _dbContext.Subscriptions
                .Where(s => s.FollowerId == user_id)
                .Select(s => s.UserToId)
                .ToListAsync(cancellationToken);

            var subscriptionTags = await _dbContext.CommonUsers
                .Where(u => subscriptionIds.Contains(u.Id))
                .Select(u => u.Tag)
                .ToListAsync(cancellationToken);

            return subscriptionTags;
        }

        public async Task<IEnumerable<string>> GetFollowersByIdAsync(int user_id, CancellationToken cancellationToken = default)
        {
            var followersIds = await _dbContext.Subscriptions
                .Where(s => s.UserToId == user_id)
                .Select(s => s.FollowerId)
                .ToListAsync(cancellationToken);

            var subscriptionTags = await _dbContext.CommonUsers
                .Where(u => followersIds.Contains(u.Id))
                .Select(u => u.Tag)
                .ToListAsync(cancellationToken);

            return subscriptionTags;
        }

        public async Task AddSubscriptionAsync(int userId, int friendId)
        {

            var subscription = new Subscription
            {
                FollowerId = userId,
                UserToId = friendId
            };

            _dbContext.Subscriptions.Add(subscription);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveSubscriptionAsync(Subscription subscription)
        {
            // var subscription = await _dbContext.Subscriptions
            //    .FirstOrDefaultAsync(s => s.FollowerId == followerId && s.UserToId == userToId);

            if (subscription != null)
            {
                _dbContext.Subscriptions.Remove(subscription);
                await _dbContext.SaveChangesAsync();
            }
        }


    }
}