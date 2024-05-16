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
        private readonly TopDbContext _context;

        public SubscriptionController(TopDbContext context, ISubscriptionTransformService subscriptionTransformService , ISubscriptionSearchService subscriptionSearchService)
        {
            _subscriptionTransformService = subscriptionTransformService;
            _subscriptionSearchService = subscriptionSearchService;
            _context = context;
        }

        [HttpGet("followers/{tag}")]
        public async Task<IActionResult> GetFollowers(string tag, CancellationToken cancellationToken)
        {
            var user = _context.CommonUsers.FirstOrDefault(u => u.Tag.Equals(tag));
            var followers = await _subscriptionSearchService.GetFollowersByIdAsync(user.Id, cancellationToken);
            return Ok(followers);
        }
        [HttpGet("subscriptions/{tag}")]
        public async Task<IActionResult> GetSubscriptions(string tag, CancellationToken cancellationToken)
        {
            var user = _context.CommonUsers.FirstOrDefault(u => u.Tag.Equals(tag));
            var subscriptions = await _subscriptionSearchService.GetSubscriptionsByIdAsync(user.Id, cancellationToken);
            return Ok(subscriptions);
        }
    }
}
