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

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ShowProfile(int id)
        {
            var dummi = await _profileService.ShowByIdAsync(id);
            return View(new ProfileViewModel(dummi));
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

            return View(new ProfileViewModel(dummi2));
        }
    }
}