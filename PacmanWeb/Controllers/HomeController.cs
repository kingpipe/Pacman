using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacmanWeb.MenagerPacman;
using PacmanWeb.Models;

namespace PacmanWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<PacmanHub> hubContext;
        private readonly Game game;

        public HomeController(IHubContext<PacmanHub> hubContext, Game game)
        {
            this.hubContext = hubContext;
            this.game = game;
        }

        public IActionResult Index()
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