using Microsoft.Extensions.Options;

namespace Tests
{
    public class BookRepositoryTests
    {
        [Fact]
        public async Task GetByGenreAsync_ReturnsFilteredBooks()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TopDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using var dbContext = new TopDbContext(options);

            var expectedGenre = "Fantasy";
            var expectedBooks = new List<Book>
            {
                new Book { 
                    Id = 1, 
                    Title = "Book 1", 
                    Genre = "Fantasy", 
                    AuthorName = "Author 1", 
                    Description = "Description 1", 
                    LanguageBook = "English", 
                    Picture = "picture.jpg", 
                    Status = "Available" 
                },
                new Book { 
                    Id = 2, 
                    Title = "Book 2", 
                    Genre = "Fantasy", 
                    AuthorName = "Author 2", 
                    Description = "Description 2", 
                    LanguageBook = "English", 
                    Picture = "picture.jpg", 
                    Status = "Available" 
                }
            };
            var unexpectedBook = new Book { 
                Id = 3, 
                Title = "Book 3", 
                Genre = "Science Fiction", 
                AuthorName = "Author 3", 
                Description = "Description 3", 
                LanguageBook = "English", 
                Picture = "picture.jpg", 
                Status = "Available" };


            dbContext.AddRange(expectedBooks);
            dbContext.SaveChanges();

            var repository = new BookRepository(dbContext);

            // Act
            var result = await repository.GetByGenreAsync(expectedGenre, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedBooks.Count, result!.Count());

            foreach (var book in result)
            {
                Assert.Equal(expectedGenre, book.Genre);
            }

            Assert.DoesNotContain(unexpectedBook, result);
        }
    }
}
