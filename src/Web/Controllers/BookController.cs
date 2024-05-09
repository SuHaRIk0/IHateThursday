using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class BookController : Controller
    {
        private readonly TopDbContext topDbContex;
        public BookController(TopDbContext topDbContex)
        {
            this.topDbContex = topDbContex;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Create(BookViewModel bookView)
        {
            var book = new Domain.Entities.Book
            {
                Id = bookView.Id,
                Title = bookView.Title,
                AuthorName = bookView.AuthorName,
                Picture = bookView.Picture,
                LanguageBook = bookView.Language,
                Genre = bookView.Genre,
                Description = bookView.Description,
                Status = bookView.Status
            };

            topDbContex.Books.Add(book);
            topDbContex.SaveChanges();

            return View("Add");
        }

        [HttpGet]
        public IActionResult Show() 
        {
            var books = topDbContex.Books.ToList();
            
            return View(books);
        }
    }
}
