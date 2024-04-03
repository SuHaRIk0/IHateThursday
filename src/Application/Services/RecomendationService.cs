using Domain.Entities;
using Domain.IRepository;
using Domain.IService;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class RecomendationService : IRecomendationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;

        private readonly ILogger<RecomendationService> _logger;

        public RecomendationService(IUserRepository userRepository, IBookRepository bookRepository, ILogger<RecomendationService> logger)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Book>?> GetRecomendationsAsync(int id)
        {
            _logger.LogInformation("Started database operations...");

            var dummy = await _userRepository.GetByIdAsync(id);

            if (dummy != null)
            {
                _logger.LogInformation("Retrivial successful!");
                return await _bookRepository.GetByGenreAsync(dummy.GenresReaded);
            }

            _logger.LogInformation("Retrivial UNsuccessful! The result is NULL!");
            return null;
        }
    }
}
