namespace Tests
{
    public class UserRepositoryTests
    {
        [Fact]
        public async Task GetByIdAsync_ReturnsUserById()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TopDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using var dbContext = new TopDbContext(options);

            var expectedId = 2;
            var expectedUser = new CommonUser
            {
                Id = 2,
                Name = "DummyPro",
                Tag = "Ultra Reader",
                Password = "1234qwer",
                Description = "Some description",
                GenresReaded = "Fantasy, Detective"
            };

            dbContext.AddRange(expectedUser);
            dbContext.SaveChanges();

            var repository = new UserRepository(dbContext);

            // Act
            var result = await repository.GetByIdAsync(expectedId, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUser, result);
        }
    }
}
