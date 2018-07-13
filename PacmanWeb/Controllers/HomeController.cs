using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PacMan;
using PacmanWeb.ManagerPacman;
using PacmanWeb.Models;

namespace PacmanWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Demoo()
        {
            return View();
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

        public IActionResult Start()
        {
            Game game = new Game("wwwroot/map.txt", new Size(30, 31));
            PacmanHub pacmanHub = new PacmanHub(game);
            pacmanHub.Start();
            return View("Map");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Map()
        {
            return View();
        }
    }
}
