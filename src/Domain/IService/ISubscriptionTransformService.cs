using Domain.DTO;
using Domain.Entities;

namespace Domain.IService
{
    public interface ISubscriptionTransformService : IService
    {
        Task<IEnumerable<SubscriptionDTO>?> GetSubscriptionDTOsAsync(IEnumerable<Subscription>? subs);
        Task<SubscriptionDTO?> GetSubscriptionDTOAsync(Subscription? sub);

    }
}