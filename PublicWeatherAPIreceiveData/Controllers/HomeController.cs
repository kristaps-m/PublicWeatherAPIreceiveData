using Microsoft.AspNetCore.Mvc;
using PublicWeatherAPIreceiveData.Models;
using System.Diagnostics;

namespace PublicWeatherAPIreceiveData.Controllers
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
            // Return the React app's index.html
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "react-app", "build", "index.html");
            _logger.LogInformation($"------ Log Path: {path}");
            return PhysicalFile(path, "text/html");
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