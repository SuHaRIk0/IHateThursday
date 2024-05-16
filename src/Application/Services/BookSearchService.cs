using Domain.Entities;
using Domain.IRepository;
using Domain.IService;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class BookSearchService : IBookSearchService
    {
        private readonly IBookRepository _bookRepository;

        private readonly ILogger<BookSearchService> _logger;

        public BookSearchService(IBookRepository bookRepository, ILogger<BookSearchService> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<Book?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Started database operations...");
            var book = await _bookRepository.GetByTitleAsync(title, cancellationToken);

            if (book != null)
            {
                _logger.LogInformation("Retrivial successful!");
                return book;
            }

            _logger.LogInformation("Retrivial UNsuccessful! The result is NULL!");
            return null;
        }
    }
}