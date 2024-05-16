using Domain.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Web.Controllers
{
    [Route("[controller]/{action=GetSearch}")]
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
        [HttpGet("{title}")]
        public async Task<IActionResult> GetSearch(string title, CancellationToken cancellationToken)
        {

            return View(title);
            // var book = await _bookSearchService.GetByTitleAsync(inputField, cancellationToken);
            // return View(await _bookTransformService.GetBookDtoAsync(book, cancellationToken));
        }
    }
}