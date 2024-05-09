//using Domain.Entities;
//using Microsoft.AspNetCore.Mvc;
//using Infrastructure.Data;
//using System.Linq;
//using Web.Models;
//using Application.Services;
//using Domain.IService;

//namespace Web.Controllers
//{
//    [Route("[controller]/{action=Profile}")]
//    public class ProfileController : Controller
//    {
//        private readonly IProfileService _profileService;

//        public ProfileController(IProfileService profileService)
//        {
//            _profileService = profileService;
//        }

//        [HttpGet("ShowProfile/{id}")]
//        public async Task<IActionResult> ShowProfile(int id)
//        {
//            var dummi = await _profileService.ShowByIdAsync(id);
//            return View(new ProfileViewModel(dummi));
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> EditProfile(int id)
//        {
//            var dummi = await _profileService.ShowByIdAsync(id);
//            return View(new ProfileViewModel(dummi));
//        }


//        //[HttpGet("{id}")]
//        //public async Task<IActionResult> EditProfile(int userId)
//        //{
//        //    var dummi = await _profileService.ShowByIdAsync(userId);
//        //    //return View(new ProfileViewModel(dummi));
//        //    return RedirectToAction("ShowProfile", "Profile", new { id = userId.ToString() });
//        //}

//        [HttpPost("{id}")]
//        public async Task<IActionResult> EditProfile(int id, CommonUser updatedUser)
//        {
//            var dummi = await _profileService.EditByIdAsync(id, updatedUser);
//            var dummi2 = await _profileService.ShowByIdAsync(id);

//            //return View(new ProfileViewModel(dummi2));
//            return RedirectToAction("ShowProfile", "Profile", new { id = id.ToString() });
//        }
//    }
//}

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
        private readonly TopDbContext topDbContex;

        public ProfileController(IProfileService profileService, TopDbContext topDbContex)
        {
            _profileService = profileService;
            this.topDbContex = topDbContex;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ShowProfile(int id)
        {
            var dummi = await _profileService.ShowByIdAsync(id);
            ProfileViewModel profile = new ProfileViewModel(dummi);

            List<Book> books = topDbContex.Books.ToList();

            UserProfileViewModel viewModel = new UserProfileViewModel
            {
                Profile = profile,
                Books = books
            };

            return View(viewModel);
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
    }
}