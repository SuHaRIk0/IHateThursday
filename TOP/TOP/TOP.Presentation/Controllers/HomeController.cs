﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TOP.Models;

namespace TOP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("/TOP.Presentation/Views/Home/Index.cshtml");
        }

        public IActionResult Privacy()
        {
            return View("/TOP.Presentation/Views/Home/Privacy.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}