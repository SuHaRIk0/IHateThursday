using Domain.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Web.Controllers
{
<<<<<<< HEAD
    [Route("[controller]/{action=GetSearch}")]
=======
    [Route("[controller]")]
>>>>>>> origin/third_block
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
<<<<<<< HEAD
        [HttpGet("{title}")]
        public async Task<IActionResult> GetSearch(string title, CancellationToken cancellationToken)
        {

            return View(title);
            // var book = await _bookSearchService.GetByTitleAsync(inputField, cancellationToken);
            // return View(await _bookTransformService.GetBookDtoAsync(book, cancellationToken));
        }
    }
}
=======
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
>>>>>>> origin/third_block
