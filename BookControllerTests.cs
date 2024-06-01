using Xunit;
using Moq;
using Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Domain.Entities;
using System.Collections.Generic;
using Web.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Linq;

public class BookControllerTests
{
    private BookController _controller;
    private TopDbContext _context;

    public BookControllerTests()
    {
        var options = new DbContextOptionsBuilder<TopDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _context = new TopDbContext(options);

        // Seed the database with some data
        _context.Books.Add(new Book { Id = 1, Title = "Test Book", AuthorName = "Test Author" });
        _context.SaveChanges();

        _controller = new BookController(_context);
    }

    [Fact]
    public void Add_ReturnsViewResult()
    {
        var result = _controller.Add();

        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void Create_ValidModel_ReturnsViewResult()
    {
        var bookViewModel = new BookViewModel
        {
            Id = 2,
            Title = "New Book",
            AuthorName = "New Author",
            Picture = "picture.png",
            Language = "English",
            Genre = "Fiction",
            Description = "A new book",
            Status = "Available"
        };

        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, "1")
        }, "mock"));

        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };

        var result = _controller.Create(bookViewModel);

        Assert.IsType<ViewResult>(result);
        Assert.Equal(2, _context.Books.Count());
        Assert.Equal(1, _context.BookStates.Count());
    }
}
