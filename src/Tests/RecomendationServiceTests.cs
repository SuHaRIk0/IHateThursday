namespace Tests
{
    public class RecomendationServiceTests
    {
        [Fact]
        public async Task GetRecomendationsAsync_UserFound_ReturnsBooks()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var bookRepositoryMock = new Mock<IBookRepository>();
            var loggerMock = new Mock<ILogger<RecomendationService>>();

            var expectedUser = new CommonUser { Id = 1, GenresReaded = "Fantasy" };
            var expectedBooks = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Genre = "Fantasy" },
                new Book { Id = 2, Title = "Book 2", Genre = "Fantasy" }
            };

            userRepositoryMock.Setup(repo => repo.GetByIdAsync(expectedUser.Id, It.IsAny<CancellationToken>())).ReturnsAsync(expectedUser);
            bookRepositoryMock.Setup(repo => repo.GetByGenreAsync(expectedUser.GenresReaded, It.IsAny<CancellationToken>())).ReturnsAsync(expectedBooks);

            var service = new RecomendationService(userRepositoryMock.Object, bookRepositoryMock.Object, loggerMock.Object);

            // Act
            var result = await service.GetRecomendationsAsync(expectedUser.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedBooks, result);
        }

        [Fact]
        public async Task GetRecomendationsAsync_UserNotFound_ReturnsNull()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var bookRepositoryMock = new Mock<IBookRepository>();
            var loggerMock = new Mock<ILogger<RecomendationService>>();

            userRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync((CommonUser)null);

            var service = new RecomendationService(userRepositoryMock.Object, bookRepositoryMock.Object, loggerMock.Object);

            // Act
            var result = await service.GetRecomendationsAsync(1);

            // Assert
            Assert.Null(result);
        }
    }
}
