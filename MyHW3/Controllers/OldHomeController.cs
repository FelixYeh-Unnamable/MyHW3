using Microsoft.AspNetCore.Mvc;
using MyHW3.Models;
using System.Diagnostics;

namespace MyHW3.Controllers
{
    public class OldHomeController : Controller
    {
        private readonly ILogger<OldHomeController> _logger;

        public OldHomeController(ILogger<OldHomeController> logger)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}