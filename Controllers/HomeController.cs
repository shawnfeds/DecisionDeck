using System.Diagnostics;
using DecisionDeck.Models;
using Microsoft.AspNetCore.Mvc;

namespace DecisionDeck.Controllers
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
            if (HttpContext.Request.Cookies["Role"] == null && HttpContext.Request.Cookies["UserId"] == null)
            {
                return Redirect("Login/Index"); 
            }

            return View();
        }

        public IActionResult ModifyUser()
        {
            return View();
        }

        public IActionResult Groups()
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
