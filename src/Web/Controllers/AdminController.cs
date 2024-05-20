using Application.Services;
using Domain.IService;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly TopDbContext _dbContext;
        private readonly IAdminService _adminService;
        private readonly IBookSearchService _bookSearchService;
        private readonly IBookTransformService _bookTransformService;
        private readonly IProfileService _profileService;

        public AdminController(TopDbContext dbContext, IAdminService adminService, IBookSearchService bookSearchService, IBookTransformService bookTransformService, IProfileService profileService)
        {
            _dbContext = dbContext;
            _adminService = adminService;
            _bookSearchService = bookSearchService;
            _bookTransformService = bookTransformService;
            _profileService = profileService;
        }

        [HttpGet("ControlPanel")]
        public async Task<IActionResult> ControlPanel()
        {
            return View();
        }

        [HttpGet("GetSearchBook")]
        public async Task<IActionResult> GetSearchBook([FromQuery] string title, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(title))
            {
                return BadRequest("Title is required.");
            }
            var book = await _bookSearchService.GetByTitleAsync(title, cancellationToken);
            return View(await _bookTransformService.GetBookDtoAsync(book, cancellationToken));
        }

        [HttpGet("GetSearchUser")]
        public async Task<IActionResult> GetSearchUser([FromQuery] string tag, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(tag))
            {
                return BadRequest("Title is required.");
            }
            var user = await _profileService.GetByTagAsync(tag);
            var userDto = new Domain.DTO.CommonUserDto(user);
            return View(userDto);
        }

        [HttpPost("DeleteBook")]
        public async Task<IActionResult> DeleteBook(int id, CancellationToken cancellationToken)
        {
            await _adminService.DeleteBookAsync(id, cancellationToken);

            return RedirectToAction("ControlPanel", "Admin");
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellationToken)
        {
            await _adminService.DeleteUserAsync(id, cancellationToken);

            return RedirectToAction("ControlPanel", "Admin");
        }
    }
}
