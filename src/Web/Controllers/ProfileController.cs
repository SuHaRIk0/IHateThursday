using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using System.Linq;
using Web.Models;
using Application.Services;
using Domain.IService;


namespace Web.Controllers
{
    [Route("[controller]/{action=Profile}")]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IBookService _bookService;
        private readonly TopDbContext topDbContex;
        private readonly ISubscriptionSearchService _subscriptionSearchService;

        public ProfileController(IProfileService profileService, IBookService bookService,ISubscriptionSearchService subscriptionSearchService, TopDbContext topDbContex)
        {
            _profileService = profileService;
            _bookService = bookService;
            _subscriptionSearchService = subscriptionSearchService;
            this.topDbContex = topDbContex;
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> ShowProfile(int id)
        //{
        //    var dummi = await _profileService.ShowByIdAsync(id);
        //    ProfileViewModel profile = new ProfileViewModel(dummi);

        //    var dummy = await _bookService.ShowBookByIdAsync(id);
        //    List<BookViewModel> books = new List<BookViewModel>();

        //    UserProfileViewModel viewModel = new UserProfileViewModel
        //    {
        //        Profile = profile,
        //        Books = books
        //    };

        //    return View(viewModel);
        //}

        public async Task<IActionResult> ShowProfile(int id)
        {
            var profile = await _profileService.ShowByIdAsync(id);
            var books = await _bookService.GetBooksByIdAsync(id);
            var subscribtions = await _subscriptionSearchService.GetSubscriptionsByIdAsync(id);
            var followers = await _subscriptionSearchService.GetFollowersByIdAsync(id);

            

            var userProfileViewModel = new UserProfileViewModel
            {
                Profile = new ProfileViewModel(profile),
                Books = books.Select(book => new BookViewModel(book)).ToList()
            };

            var subInfoViewModel = new SubInfoViewModel
            {
                followers_amount = followers.Count(),
                subscribtions_amount = subscribtions.Count(),
                followers = followers.ToList(),
                subscriptions = subscribtions.ToList()
            };

            var fullProfile = new FullProfileViewModel {
                profileViewModel = userProfileViewModel,
                subInfoViewModel = subInfoViewModel
            };

            return View(fullProfile);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> EditProfile(int id)
        {
            var dummi = await _profileService.ShowByIdAsync(id);
            return View(new ProfileViewModel(dummi));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> EditProfile(int id, CommonUser updatedUser)
        {
            var dummi = await _profileService.EditByIdAsync(id, updatedUser);
            var dummi2 = await _profileService.ShowByIdAsync(id);

            //return View(new ProfileViewModel(dummi2));
            return RedirectToAction("ShowProfile", "Profile", new { id = id.ToString() });
        }

        [HttpGet]
        public IActionResult FindNewFriend(int id)
        {
            var model = new FindNewFriendViewModel { CurrentUserId = id };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SearchFriend(FindNewFriendViewModel model)
        {

            var user = await _profileService.GetByTagAsync(model.Tag);

            if (user == null)
            {
                return View("FindNewFriend", model);
            }

            model.FoundUser = user;

            return View("FindNewFriend", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddFriend(FindNewFriendViewModel model)
        {
            if (model.FoundUser == null)
            {
                return NotFound();
            }

            await _subscriptionSearchService.AddSubscriptionAsync(model.CurrentUserId, model.FoundUser.Id);
            return RedirectToAction("ShowProfile", new { id = model.CurrentUserId });
        }


        [HttpPost]
        public async Task<IActionResult> Unfollow(int currentUserId, string subscriptionTag)
        {
            var subscriptionUser = await _profileService.GetByTagAsync(subscriptionTag);

            if (subscriptionUser != null)
            {
                var subscription = await _subscriptionSearchService.GetSubscriptionByIdAsync(currentUserId, subscriptionUser.Id);

                await _subscriptionSearchService.RemoveSubscriptionAsync(subscription);
            }

            return RedirectToAction("ShowProfile", new { id = currentUserId });
        }


        [HttpPost]
        public async Task<IActionResult> RemoveFollower(int currentUserId, string followerTag)
        {
            var followerUser = await _profileService.GetByTagAsync(followerTag);

            if (followerUser != null)
            {
                var subscription = await _subscriptionSearchService.GetSubscriptionByIdAsync(followerUser.Id , currentUserId);

                await _subscriptionSearchService.RemoveSubscriptionAsync(subscription);
            }

            return RedirectToAction("ShowProfile", new { id = currentUserId });
        }

    }
}