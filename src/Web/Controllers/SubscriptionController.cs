using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using System.Linq;
using Web.Models;

namespace Web.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly TopDbContext _context;

        public SubscriptionController(TopDbContext context)
        {
            _context = context;
        }

        public IActionResult ShowProfile(int id)
        {
            var user = _context.CommonUsers.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            var model = new ProfileViewModel
            {
                Name = user.Name,
                Tag = user.Tag,
                Description = user.Description,
                GenresReaded = user.GenresReaded
            };

            //var model = new ProfileViewModel
            //{
            //    Id = 1,
            //    Name = "Iryna",
            //    Tag = "IZ",
            //    Description = "I love a book",
            //    GenresReaded = "Fiction, Mystery"
            //};

            return View(model); 
        }
    }
}
