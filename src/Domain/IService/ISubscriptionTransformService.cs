using Domain.DTO;
using Domain.Entities;

namespace Domain.IService
{
    public interface ISubscriptionTransformService : IService
    {
        Task<IEnumerable<SubscriptionDTO>?> GetSubscriptionDTOsAsync(IEnumerable<Subscription>? subs, CancellationToken cancellationToken);
        Task<SubscriptionDTO?> GetSubscriptionDTOAsync(Subscription? sub, CancellationToken cancellationToken);

    }
}
