using Domain.IService;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("[controller]/{action=GetRecomendations}")]
    public class RecomendationsController : Controller
    {
        private readonly IRecomendationService _recomendationService;
        private readonly IBookTransformService _bookTransformService;

        public RecomendationsController(IRecomendationService recomendationService, IBookTransformService bookTransformService)
        {
            _recomendationService = recomendationService;
            _bookTransformService = bookTransformService;
        }

        // Matches Recomendations/GetRecomendations/2
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecomendations(int id)
        {
            var books = await _recomendationService.GetRecomendationsAsync(id);
            
            return View(await _bookTransformService.GetBookDtosAsync(books));
        }
    }
}
