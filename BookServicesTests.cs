namespace Tests
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly Mock<ILogger<BookService>> _mockLogger;
        private readonly BookService _bookService;

        public BookServiceTests()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _mockLogger = new Mock<ILogger<BookService>>();
            _bookService = new BookService(_mockBookRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task EditBookByIdAsync_BookExists_ReturnsTrue()
        {
            // Arrange
            var existingBook = new Book { Id = 1, Title = "Old Title", AuthorName = "Old Author" };
            var updatedBook = new Book { Id = 1, Title = "New Title", AuthorName = "New Author" };

            _mockBookRepository.Setup(repo => repo.GetBookByIdAsync(1, default)).ReturnsAsync(existingBook);
            _mockBookRepository.Setup(repo => repo.EditBookByIdAsync(1, updatedBook, default)).ReturnsAsync(true);

            // Act
            var result = await _bookService.EditBookByIdAsync(1, updatedBook);

            // Assert
            Assert.True(result);
            _mockLogger.Verify(log => log.LogInformation("Retrivial successful!"), Times.Once);
            _mockBookRepository.Verify(repo => repo.EditBookByIdAsync(1, existingBook, default), Times.Once);
        }

        [Fact]
        public async Task EditBookByIdAsync_BookDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var updatedBook = new Book { Id = 1, Title = "New Title", AuthorName = "New Author" };

            _mockBookRepository.Setup(repo => repo.GetBookByIdAsync(1, default)).ReturnsAsync((Book)null);

            // Act
            var result = await _bookService.EditBookByIdAsync(1, updatedBook);

            // Assert
            Assert.False(result);
            _mockLogger.Verify(log => log.LogInformation("Retrivial UNsuccessful! The result is NULL!"), Times.Once);
            _mockBookRepository.Verify(repo => repo.EditBookByIdAsync(It.IsAny<int>(), It.IsAny<Book>(), default), Times.Never);
        }
    }
}