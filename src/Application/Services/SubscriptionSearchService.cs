using Domain.Entities;
using Domain.IRepository;
using Domain.IService;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class SubscriptionSearchService : ISubscriptionSearchService
    {
        private readonly ISubscriptionRepository _subsRepository;

        private readonly ILogger<SubscriptionSearchService> _logger;

        public SubscriptionSearchService(ISubscriptionRepository subRepository, ILogger<SubscriptionSearchService> logger)
        {
            _subsRepository = subRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Subscription>> GetFollowersByIdAsync(int userId, CancellationToken cancellationToken)
        {
            return await _subsRepository.GetSubscriptionsByIdAsync(userId, cancellationToken);
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsByIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            return await _subsRepository.GetFollowersByIdAsync(userId, cancellationToken);
        }
    }
}