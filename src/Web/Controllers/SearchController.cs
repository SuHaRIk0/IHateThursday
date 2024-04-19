using Domain.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Web.Controllers
{
    [Route("[controller]")]
    public class SearchController : Controller
    {
        private readonly IBookSearchService _bookSearchService;
        private readonly IBookTransformService _bookTransformService;

        public SearchController(IBookSearchService bookSearchService, IBookTransformService bookTransformService)
        {
            _bookSearchService = bookSearchService;
            _bookTransformService = bookTransformService;
        }

        // Matches Search/GetSearch?title=Harry+Potter+and+the+Sorcerers+Stone
        [HttpGet("GetSearch")]
        public async Task<IActionResult> GetSearch([FromQuery] string title, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(title))
            {
                // Обробка помилки, якщо заголовок відсутній
                return BadRequest("Title is required.");
            }
            var book = await _bookSearchService.GetByTitleAsync(title, cancellationToken);
            return View(await _bookTransformService.GetBookDtoAsync(book, cancellationToken));
        }
    }
}
