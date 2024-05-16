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

        public async Task<IEnumerable<Book>?> GetRecomendationsAsync(int id, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Started database operations...");

            var dummy = await _userRepository.GetByIdAsync(id, cancellationToken);

            if (dummy != null)
            {
                _logger.LogInformation("Retrivial successful!");
                return await _bookRepository.GetByGenreAsync(dummy.GenresReaded, cancellationToken);
            }

            _logger.LogInformation("Retrivial UNsuccessful! The result is NULL!");
            return null;
        }
    }
}