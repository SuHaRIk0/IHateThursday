using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.IService;
using Web.Models;
using System;

namespace Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAuthService _authService;

        public RegisterController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tag = "@" + model.UserName.ToLower();
                var user = new CommonUser { Email = model.Email, UserName = model.UserName, Name = "test", Tag = tag, Password = model.Password, Description = "I`m cool!", GenresReaded = "Horror" };
                var result = await _authService.RegisterAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}