using Domain.Entities;
using Domain.IRepository;
using Domain.IService;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<string>> GetFollowersByIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var followerTags = await _subsRepository.GetFollowersByIdAsync(userId, cancellationToken);
            return followerTags ?? new List<string>();
        }

        public async Task<IEnumerable<string>> GetSubscriptionsByIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var subscriptionTags = await _subsRepository.GetSubscriptionsByIdAsync(userId, cancellationToken);
            return subscriptionTags ?? new List<string>();
        }

        public async Task AddSubscriptionAsync(int userId, int friendId)
        {
            _subsRepository.AddSubscriptionAsync(userId, friendId);
        }

        public async Task RemoveSubscriptionAsync(Subscription sub)
        {
            _subsRepository.RemoveSubscriptionAsync(sub);
        }

        public async Task<Subscription?> GetSubscriptionByIdAsync(int follower, int userToId, CancellationToken cancellationToken = default)
        {
            var sub = await _subsRepository.GetSubscriptionByIdAsync(follower,userToId);

            return sub;
        }
    }
}