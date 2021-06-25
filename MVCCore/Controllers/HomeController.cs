using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        

        public string Index2()
        {
            //return Environment.GetEnvironmentVariable("Some_Random_Variable");
            return "Hello World!";
        }

        public ViewResult Index()
        {
            ViewData["Message"] = "Application Index page";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
