using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.IService
{
    public interface ISubscriptionSearchService : IService
    {
        Task<Subscription?> GetSubscriptionByIdAsync(int follower, int userToId, CancellationToken cancellationToken = default);
        Task<IEnumerable<string>?> GetFollowersByIdAsync(int user_id, CancellationToken cancellationToken = default);
        Task<IEnumerable<string>?> GetSubscriptionsByIdAsync(int user_id, CancellationToken cancellationToken = default);
        Task AddSubscriptionAsync(int userId, int friendId);
        Task RemoveSubscriptionAsync(Subscription subscription);

    }
}
