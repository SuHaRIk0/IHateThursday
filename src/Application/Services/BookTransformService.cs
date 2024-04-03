using Domain.DTO;
using Domain.Entities;
using Domain.IService;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class BookTransformService : IBookTransformService
    {
        private readonly ILogger<BookTransformService> _logger;

        public BookTransformService(ILogger<BookTransformService> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<BookDto>?> GetBookDtosAsync(IEnumerable<Book>? books)
        {
            _logger.LogInformation("Trying to convert books type...");

            if (books == null)
            {
                _logger.LogInformation("Input collection is null, returning null.");
                return null;
            }

            var tasks = books.Select(async book =>
            {
                await Task.Yield();
                return new BookDto(book);
            });

            var result = await Task.WhenAll(tasks);

            _logger.LogInformation("Conversion successful!");

            return result;
        }

    }
}
