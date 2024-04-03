namespace Tests
{
    public class BookTransformServiceTests
    {
        [Fact]
        public async Task GetBookDtosAsync_NullInput_ReturnsNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<BookTransformService>>();
            var service = new BookTransformService(loggerMock.Object);

            // Act
            var result = await service.GetBookDtosAsync(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetBookDtosAsync_EmptyInput_ReturnsEmptyCollection()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<BookTransformService>>();
            var service = new BookTransformService(loggerMock.Object);

            // Act
            var result = await service.GetBookDtosAsync(Enumerable.Empty<Book>());

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetBookDtosAsync_NonEmptyInput_ReturnsBookDtos()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<BookTransformService>>();
            var service = new BookTransformService(loggerMock.Object);
            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1" },
                new Book { Id = 2, Title = "Book 2" },
                new Book { Id = 3, Title = "Book 3" }
            };

            // Act
            var result = await service.GetBookDtosAsync(books);

            // Assert
            Assert.Equal(books.Count, result.Count());
            foreach (var bookDto in result)
            {
                Assert.NotNull(bookDto);
                Assert.Contains(books, book => bookDto.Id == book.Id && bookDto.Title == book.Title);
            }
        }
    }
}