namespace Tests
{
    public class BookRepositoryTests
    {
        private BookRepository _repository;
        private TopDbContext _context;

        public BookRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<TopDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new TopDbContext(options);

            // Seed the database with some data
            _context.Books.Add(new Book
            {
                Id = 1,
                Title = "The Fountainhead",
                AuthorName = "Ayn Rand",
                Genre = "Fiction",
                Description = "Description 1",
                LanguageBook = "English",
                Picture = "title.jpg",
                Status = "finished"
            });
            _context.BookStates.Add(new BookState
            {
                Id = 1,
                BookId = 1,
                UserId = 1,
                StateBook = "finished",
                LikeBook = true
            });
            _context.SaveChanges();

            _repository = new BookRepository(_context);
        }

        [Fact]
        public async Task EditBookByIdAsync_UpdatesBook_ReturnsTrue()
        {
            var bookToUpdate = new Book
            {
                Id = 1,
                Title = "Updated Book",
                AuthorName = "Updated Author",
                Genre = "Updated Genre",
                Description = "Updated Description",
                LanguageBook = "Updated English",
                Picture = "Updated.jpg",
                Status = "planning"
            };

            var result = await _repository.EditBookByIdAsync(1, bookToUpdate);

            Assert.True(result);
            var updatedBook = await _context.Books.FindAsync(1);
            Assert.Equal("Updated Book", updatedBook.Title);
        }


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
            var unexpectedBook = new Book
            {
                Id = 3,
                Title = "Book 3",
                Genre = "Science Fiction",
                AuthorName = "Author 3",
                Description = "Description 3",
                LanguageBook = "English",
                Picture = "picture.jpg",
                Status = "Available"
            };


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


        [Fact]
        public async Task DeleteBookByIdAsync_DeletesBook_ReturnsTrue()
        {
            var result = await _repository.DeleteBookByIdAsync(1);

            Assert.True(result);
            var deletedBook = await _context.Books.FindAsync(1);
            Assert.Null(deletedBook);
        }

        [Fact]
        public async Task DeleteBookByIdAsync_BookNotFound_ReturnsFalse()
        {
            var result = await _repository.DeleteBookByIdAsync(2);

            Assert.False(result);
        }
    }
}