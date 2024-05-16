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
        Task<IEnumerable<Subscription>?> GetFollowersByIdAsync(int user_id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Subscription>?> GetSubscriptionsByIdAsync(int user_id, CancellationToken cancellationToken = default);
    }
}
