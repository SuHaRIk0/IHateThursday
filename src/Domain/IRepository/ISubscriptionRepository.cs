using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {

        Task<Subscription?> GetSubscriptionByIdAsync(int follower, int userToId, CancellationToken cancellationToken = default);

        Task<IEnumerable<string>?> GetFollowersByIdAsync(int user_id, CancellationToken cancellationToken = default);

        Task<IEnumerable<string>?> GetSubscriptionsByIdAsync(int user_id, CancellationToken cancellationToken = default);

        Task AddSubscriptionAsync(int userId, int friendId);

        Task RemoveSubscriptionAsync(Subscription subscription);
    }
}