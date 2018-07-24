using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PacmanWeb.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BlueMap()
        {
            return View();
        }

        public IActionResult GreenMap()
        {
            return View();
        }
    }
}