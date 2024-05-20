using Domain.DTO;
using Domain.Entities;
using Domain.IService;
using Microsoft.Extensions.Logging;


namespace Application.Services
{
    public class SubscriptionTransformService : ISubscriptionTransformService
    {
        private readonly ILogger<SubscriptionTransformService> _logger;

        public SubscriptionTransformService(ILogger<SubscriptionTransformService> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<SubscriptionDTO>?> GetSubscriptionDTOsAsync(IEnumerable<Subscription>? subs)
        {
            _logger.LogInformation("Trying to convert subscriptions type...");

            if (subs == null)
            {
                _logger.LogInformation("Input collection is null, returning null.");
                return null;
            }

            var tasks = subs.Select(async sub =>
            {
                await Task.Yield();
                return new SubscriptionDTO(sub);
            });

            var result = await Task.WhenAll(tasks);

            _logger.LogInformation("Conversion successful!");

            return result;
        }

        public async Task<SubscriptionDTO?> GetSubscriptionDTOAsync(Subscription? sub)
        {
            _logger.LogInformation("Trying to convert subscription type...");

            if (sub == null)
            {
                _logger.LogInformation("Input object is null, returning null.");
                return null;
            }
            var subDto = await Task.Run(() => new SubscriptionDTO(sub));

            _logger.LogInformation("Conversion successful!");

            return subDto;
        }
    }
}