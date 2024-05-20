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

        public SubscriptionController(TopDbContext context, ISubscriptionTransformService subscriptionTransformService, ISubscriptionSearchService subscriptionSearchService)
        {
            _subscriptionTransformService = subscriptionTransformService;
            _subscriptionSearchService = subscriptionSearchService;
            _context = context;
        }



    }
}