using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.IService;
using Web.Models;
using System.Drawing.Printing;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(AuthViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _authService.LoginAsync(model.Email, model.RememberMe, model.Password);

        //        if (result.Succeeded)
        //        {
        //            var userId = await _authService.GetUserIdAsync(model.Email);

        //            userId = 1;

        //            if (userId != null)
        //            {
        //                //return RedirectToAction("ShowProfile", "Profile", userId);
        //                return RedirectToAction("ShowProfile", "Profile", new { id = userId } );
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //        }
        //    }

        //    Console.WriteLine(ModelState);

        //    return View("Login", model);
        //}

        [HttpPost]
        public async Task<IActionResult> Login(LogViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginAsync(model.Email, model.RememberMe, model.Password);

                if (result.Succeeded)
                {
                    var user = await _authService.GetUserAsync(model.Email);

                    if (user != null)
                    {
                        var userId = user.Id;

                        if (userId != null)
                        {
                            return RedirectToAction("ShowProfile", "Profile", new { id = userId.ToString() });
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return View("Login", model);
        }


        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
