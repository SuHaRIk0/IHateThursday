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

<<<<<<< HEAD
        public async Task<IEnumerable<BookDto>?> GetBookDtosAsync(IEnumerable<Book>? books, CancellationToken cancellationToken = default)
=======
        public async Task<IEnumerable<BookDto>?> GetBookDtosAsync(IEnumerable<Book>? books, CancellationToken cancellationToken=default)
>>>>>>> origin/third_block
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

<<<<<<< HEAD
        public async Task<BookDto?> GetBookDtoAsync(Book? book, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Trying to convert book type...");

            if (book == null)
=======
        public async Task<BookDto?> GetBookDtoAsync(Book? book, CancellationToken cancellationToken=default)
        {
            _logger.LogInformation("Trying to convert book type...");

            if (book == null) 
>>>>>>> origin/third_block
            {
                _logger.LogInformation("Input object is null, returning null.");
                return null;
            }
            var bookDto = await Task.Run(() => new BookDto(book));

            _logger.LogInformation("Conversion successful!");

            return bookDto;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> origin/third_block
