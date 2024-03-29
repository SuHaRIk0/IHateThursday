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

        public IEnumerable<BookDto> GetRecomendations(int id)
        {
            try
            {
                _logger.LogInformation("Started database operations...");
                _logger.LogDebug("Retrieving user data from CommonUsers table...");

                var taskOne = _userRepository.GetByIdAsync(id);
                taskOne.Wait();
                var dummy = taskOne.Result;

                _logger.LogInformation("Retrivial successful!");


                _logger.LogDebug("Retrieving book data from Books table...");

                var taskTwo = _bookRepository.GetByGenreAsync(dummy.GenresReaded);
                taskTwo.Wait();

                _logger.LogInformation("Retrivial successful!");

                return taskTwo.Result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Oops! Something went wrong! Details: {0}", ex.Message);
                return null;
            }
        }
    }
}
