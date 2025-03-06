using System.Diagnostics;
using DecisionDeck.Contracts;
using DecisionDeck.Models;
using DecisionDeck.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DecisionDeck.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            if (HttpContext.Request.Cookies["Role"] == null && HttpContext.Request.Cookies["UserId"] == null)
            {
                return Redirect("Login/Index"); 
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
