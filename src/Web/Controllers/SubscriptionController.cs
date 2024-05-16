using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using System.Linq;
using Web.Models;
using Domain.IService;

namespace Web.Controllers
{
    [Route("[controller]/{action=GetSubscription}")]
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionTransformService _subscriptionTransformService;
        private readonly ISubscriptionSearchService _subscriptionSearchService;


        public SubscriptionController(ISubscriptionTransformService subscriptionTransformService , ISubscriptionSearchService subscriptionSearchService)
        {
            _subscriptionTransformService = subscriptionTransformService;
            _subscriptionSearchService = subscriptionSearchService;
        }

        [HttpGet("followers/{tag}")]
        public async Task<IActionResult> GetFollowers(string tag, CancellationToken cancellationToken)
        {
            var followers = await _subscriptionSearchService.GetFollowersByIdAsync(1, cancellationToken);
            return Ok(followers);
        }
        [HttpGet("subscriptions/{tag}")]
        public async Task<IActionResult> GetSubscriptions(string tag, CancellationToken cancellationToken)
        {
            var subscriptions = await _subscriptionSearchService.GetSubscriptionsByIdAsync(1, cancellationToken);
            return Ok(subscriptions);
        }
    }
}
