using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BTChat.ThirdPlatfrom.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        public string Index()
        {
            return "hello";
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
