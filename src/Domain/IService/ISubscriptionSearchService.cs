using Domain.DTO;
using Domain.Entities;

namespace Domain.IService
{
    public interface ISubscriptionSearchService : IService
    {
        Task<IEnumerable<Subscription>?> GetFollowersByIdAsync(int user_id, CancellationToken cancellationToken);
        Task<IEnumerable<Subscription>?> GetSubscriptionsByIdAsync(int user_id, CancellationToken cancellationToken);

    }
}
