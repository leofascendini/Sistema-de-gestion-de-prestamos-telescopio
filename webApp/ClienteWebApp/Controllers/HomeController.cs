using ClienteWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClienteWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            string token = HttpContext.Session.GetString("token");

            ViewBag.Token = token;
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
