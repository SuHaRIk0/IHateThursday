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

        //[HttpGet]
        //public IActionResult ShowProfile(int id)
        //{
        //    var user = _context.CommonUsers.FirstOrDefault(u => u.Id == id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    var model = new ProfileViewModel
        //    {
        //        Name = user.Name,
        //        Tag = user.Tag,
        //        Description = user.Description,
        //        GenresReaded = user.GenresReaded
        //    };

        //    return View(model);
        //}

        //[HttpGet]
        //public IActionResult EditProfile(int id)
        //{
        //    var user = _context.CommonUsers.FirstOrDefault(u => u.Id == id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    var model = new ProfileViewModel
        //    {
        //        Id = user.Id,
        //        Name = user.Name,
        //        Tag = user.Tag,
        //        Description = user.Description,
        //        GenresReaded = user.GenresReaded
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditProfile(ProfileViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var user = _context.CommonUsers.FirstOrDefault(u => u.Id == model.Id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    user.Name = model.Name;
        //    user.Tag = model.Tag;
        //    user.Description = model.Description;
        //    user.GenresReaded = model.GenresReaded;

        //    _context.SaveChanges();

        //    return RedirectToAction(nameof(ShowProfile), new { id = user.Id });
        //}

        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ShowProfile(int id)
        {
            return View(await _profileService.ShowByIdAsync(id));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> EditProfile(int id, CommonUser updatedUser)
        {
            var dummi = await _profileService.EditByIdAsync(id, updatedUser);

            return View(await _profileService.ShowByIdAsync(id));
        }
    }
}


//using Domain.IService;
//using Microsoft.AspNetCore.Mvc;

//namespace Web.Controllers
//{
//    [Route("[controller]/{action=GetRecomendations}")]
//    public class RecomendationsController : Controller
//    {
//        private readonly IRecomendationService _recomendationService;
//        private readonly IBookTransformService _bookTransformService;

//        public RecomendationsController(IRecomendationService recomendationService, IBookTransformService bookTransformService)
//        {
//            _recomendationService = recomendationService;
//            _bookTransformService = bookTransformService;
//        }

//        // Matches Recomendations/GetRecomendations/2
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetRecomendations(int id)
//        {
//            var books = await _recomendationService.GetRecomendationsAsync(id);

//            return View(await _bookTransformService.GetBookDtosAsync(books));
//        }
//    }
//}