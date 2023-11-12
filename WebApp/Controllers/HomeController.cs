using ComplaintLoggingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ComplaintLoggingSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Complaint Logging System";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact us";

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
