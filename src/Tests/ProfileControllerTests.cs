using System.Collections.Generic;

namespace Tests
{
    public class ProfileControllerTests
    {
        [Fact]
        public void Test1()
        {

        }
    }
}

////using NUnit.Framework;
////using Moq;
////using Microsoft.AspNetCore.Mvc;
////using Microsoft.EntityFrameworkCore;
////using System.Collections.Generic;
////using System.Linq;
////using Web.Controllers;
////using Web.Models;
////using Infrastructure.Data;
////using Domain.Entities;

////namespace UnitTests.Controllers
////{
////    [TestFixture]
////    public class ProfileControllerTests
////    {
////        private ProfileController _controller;
////        private Mock<TopDbContext> _contextMock;
////        private Mock<DbSet<CommonUser>> _dbSetMock;

////        [SetUp]
////        public void Setup()
////        {
////            var users = new List<CommonUser>
////        {
////            new CommonUser { Id = 10, Name = "John", Tag = "john123", Description = "A profile description", GenresReaded = "Fantasy" }
////            }.AsQueryable();

////            _dbSetMock = new Mock<DbSet<CommonUser>>();
////            _dbSetMock.As<IQueryable<CommonUser>>().Setup(m => m.Provider).Returns(users.Provider);
////            _dbSetMock.As<IQueryable<CommonUser>>().Setup(m => m.Expression).Returns(users.Expression);
////            _dbSetMock.As<IQueryable<CommonUser>>().Setup(m => m.ElementType).Returns(users.ElementType);
////            _dbSetMock.As<IQueryable<CommonUser>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

////            _contextMock = new Mock<TopDbContext>();
////            _contextMock.Setup(c => c.Set<CommonUser>()).Returns(_dbSetMock.Object);

////            var options = new DbContextOptionsBuilder<TopDbContext>()
////                .UseInMemoryDatabase(databaseName: "TestDatabase")
////                .Options;

////            _contextMock.Setup(c => c.SaveChanges()).Returns(1);

////            _controller = new ProfileController(new TopDbContext(options));
////        }

////        [Test]
////        public void ShowProfile_ReturnsViewResult_WithValidModel()
////        {
////            int userId = 10;

////            var result = _controller.ShowProfile(userId) as ViewResult;

////            Assert.IsNotNull(result);
////            Assert.IsInstanceOf<ProfileViewModel>(result.Model);
////            var model = result.Model as ProfileViewModel;
////            Assert.AreEqual("John", model.Name);
////            Assert.AreEqual("john123", model.Tag);
////            Assert.AreEqual("A profile description", model.Description);
////            Assert.AreEqual("Fantasy", model.GenresReaded);
////        }

////        [Test]
////        public void EditProfile_GET_ReturnsViewResult_WithValidModel()
////        {
////            int userId = 10;

////            var result = _controller.EditProfile(userId) as ViewResult;

////            Assert.IsNotNull(result);
////            Assert.IsInstanceOf<ProfileViewModel>(result.Model);
////            var model = result.Model as ProfileViewModel;
////            Assert.AreEqual(userId, model.Id);
////            Assert.AreEqual("John", model.Name);
////            Assert.AreEqual("john123", model.Tag);
////            Assert.AreEqual("A profile description", model.Description);
////            Assert.AreEqual("Fantasy", model.GenresReaded);
////        }

////        [Test]
////        public void EditProfile_POST_ReturnsRedirectToActionResult_WithValidModel()
////        {
////            var model = new ProfileViewModel { Id = 10, Name = "John", Tag = "john123", Description = "A profile description", GenresReaded = "Fantasy" };

////            var result = _controller.EditProfile(model) as RedirectToActionResult;

////            Assert.IsNotNull(result);
////            Assert.AreEqual("ShowProfile", result.ActionName);
////            Assert.AreEqual(model.Id, result.RouteValues["id"]);
////        }

////    }
////}



//namespace Tests
//{
//    public class RecomendationServiceTests
//    {
//        [Fact]
//        public async Task GetRecomendationsAsync_UserFound_ReturnsBooks()
//        {
//            // Arrange
//            var userRepositoryMock = new Mock<IUserRepository>();
//            var bookRepositoryMock = new Mock<IBookRepository>();
//            var loggerMock = new Mock<ILogger<RecomendationService>>();

//            var expectedUser = new CommonUser { Id = 1, GenresReaded = "Fantasy" };
//            var expectedBooks = new List<Book>
//            {
//                new Book { Id = 1, Title = "Book 1", Genre = "Fantasy" },
//                new Book { Id = 2, Title = "Book 2", Genre = "Fantasy" }
//            };

//            userRepositoryMock.Setup(repo => repo.GetByIdAsync(expectedUser.Id, It.IsAny<CancellationToken>())).ReturnsAsync(expectedUser);
//            bookRepositoryMock.Setup(repo => repo.GetByGenreAsync(expectedUser.GenresReaded, It.IsAny<CancellationToken>())).ReturnsAsync(expectedBooks);

//            var service = new RecomendationService(userRepositoryMock.Object, bookRepositoryMock.Object, loggerMock.Object);

//            // Act
//            var result = await service.GetRecomendationsAsync(expectedUser.Id);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(expectedBooks, result);
//        }

//        [Fact]
//        public async Task GetRecomendationsAsync_UserNotFound_ReturnsNull()
//        {
//            // Arrange
//            var userRepositoryMock = new Mock<IUserRepository>();
//            var bookRepositoryMock = new Mock<IBookRepository>();
//            var loggerMock = new Mock<ILogger<RecomendationService>>();

//            userRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync((CommonUser)null);

//            var service = new RecomendationService(userRepositoryMock.Object, bookRepositoryMock.Object, loggerMock.Object);

//            // Act
//            var result = await service.GetRecomendationsAsync(1);

//            // Assert
//            Assert.Null(result);
//        }
//    }
//}