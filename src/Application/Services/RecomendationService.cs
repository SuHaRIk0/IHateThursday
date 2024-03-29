using Domain.DTO;
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

        public async Task<IEnumerable<BookDto>> GetRecomendationsAsync(int id)
        {
            _logger.LogInformation("Started database operations...");
            _logger.LogInformation("Retrieving user data from CommonUsers table...");

            var dummy = await _userRepository.GetByIdAsync(id);

            _logger.LogInformation("Retrivial successful!");


            _logger.LogInformation("Retrieving book data from Books table...");

            var result = await _bookRepository.GetByGenreAsync(dummy.GenresReaded);

            _logger.LogInformation("Retrivial successful!");

            return result;
        }
    }
}
