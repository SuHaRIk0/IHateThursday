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
        Task<IEnumerable<Subscription>?> GetSubsByGenreAsync(string title, CancellationToken cancellationToken = default);
        Task<IEnumerable<Subscription>?> GetFollowersByTitleAsync(string title, CancellationToken cancellationToken = default);

    }
}
