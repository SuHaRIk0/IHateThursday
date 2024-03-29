using Domain.IService;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class RecomendationsController : Controller
    {
        private readonly IRecomendationService _recomendationService;

        public RecomendationsController(IRecomendationService recomendationService)
        {
            _recomendationService = recomendationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecomendations(int id)
        {
            var books = _recomendationService.GetRecomendations(id);
            if (books == null) {
                return NotFound();
            }
            return View(books);
        }
    }
}
