using System.Diagnostics;
using LFA_Project_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace LFA_Project_1.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string inputString, string pattern)
        {
            try
            {
                bool isMatch = Regex.IsMatch(inputString, pattern);
                string result = isMatch ? "Match found!" : "No match found.";
                ViewData["Result"] = result;
            }
            catch (ArgumentException ex)
            {
                ViewData["Result"] = $"Error: {ex.Message}";
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
