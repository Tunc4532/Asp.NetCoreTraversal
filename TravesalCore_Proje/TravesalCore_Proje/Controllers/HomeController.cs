﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravesalCore_Proje.Models;

namespace TravesalCore_Proje.Controllers
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

            _logger.LogInformation("Index sayfası çağırıldı");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy sayfası çağırıldı");
            return View();
        }
        public IActionResult Test()
        {
            _logger.LogInformation("Test sayfası çağırıldı");
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}