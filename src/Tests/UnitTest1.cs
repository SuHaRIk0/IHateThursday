using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Tests
{
    [TestClass]
    public class RecomendationServiceTests
    {
        [TestMethod]
        public async Task GetRecomendations_ReturnsListOfBooks()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var bookRepositoryMock = new Mock<IBookRepository>();
            var loggerMock = new Mock<ILogger<RecomendationService>>();

            var recomendationService = new RecomendationService(userRepositoryMock.Object, bookRepositoryMock.Object, loggerMock.Object);

            var userId = 1;
            var userGenres = new List<string> { "Fantasy, Adventure" };
            var dummyUser = new User { Id = userId, GenresReaded = userGenres };

            var mockBooks = new List<BookDto>
            {
                new BookDto { Title = "Book1", Genre = "Fantasy" },
                new BookDto { Title = "Book2", Genre = "Adventure" },
                new BookDto { Title = "Book3", Genre = "Sci-Fi" }
            };

            userRepositoryMock.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync(dummyUser);
            bookRepositoryMock.Setup(repo => repo.GetByGenreAsync(userGenres)).ReturnsAsync(mockBooks);

            // Act
            var result = await recomendationService.GetRecomendations(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }
    }
}
