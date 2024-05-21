using Domain.Entities;
using Humanizer.Localisation;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using Domain.IRepository;
using Domain.IService;

namespace Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Create(BookViewModel bookView)
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

            await _bookService.AddAsync(book);
            //await bookRepository.AddAsync(book);

            return View("Add");
        }

        //[HttpGet]
        //public async Task<IActionResult> Show() 
        //{
        //    var books = await bookRepository.GetBooks();
            
        //    return View(books);
        //}

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.ShowBookByIdAsync(id);

            if(book != null)
            {
                var editBook = new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    AuthorName = book.AuthorName,
                    Picture = book.Picture,
                    Language = book.LanguageBook,
                    Genre = book.Genre,
                    Description = book.Description,
                    Status = book.Status
                };

                return View(editBook);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookViewModel bookViewModel)
        {
            var book = new Book
            {
                Id = bookViewModel.Id,
                Title = bookViewModel.Title,
                AuthorName = bookViewModel.AuthorName,
                Picture = bookViewModel.Picture,
                LanguageBook = bookViewModel.Language,
                Genre = bookViewModel.Genre,
                Description = bookViewModel.Description,
                Status = bookViewModel.Status
            };

            var updatedBook = await _bookService.EditBookByIdAsync(book.Id, book);
            //var updatedBook = await bookRepository.UpdateAsync(book);

            return RedirectToAction("Edit", new { id = bookViewModel.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BookViewModel bookViewModel)
        {
            var deletedBook = await _bookService.DeleteAsync(bookViewModel.Id);

            if(deletedBook != false)
            {
                return RedirectToAction("Edit", new { id = bookViewModel.Id });
            }

            return RedirectToAction("Edit", new { id = bookViewModel.Id });
        }
    }
}
