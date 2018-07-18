using System.IO;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacmanWeb.ManagerPacman;
using PacmanWeb.Models;
using PacMan.Interfaces;
using System;
using System.Threading.Tasks;

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
        
        private void Game_PacmanIsDied()
        {
        }

        private void Move(ICoord coord)
        {
            Task.Run(() => hubContext.Clients.All.SendAsync("Move", coord.Position.X, coord.Position.Y, coord.GetId()));
        }

        private void PacmanMove(ICoord coord)
        {
            Task.Run(() => hubContext.Clients.All.SendAsync("PacmanMove", coord.Position.X, coord.Position.Y, coord.GetId(), game.Score));
        }

        public void Update()
        {
            Task.Run(() => hubContext.Clients.All.SendAsync("Init"));
        }

        public void PacmanDirection(string direction)
        {
            switch (direction)
            {
                case "37":
                    game.SetDirection(Direction.Left);
                    break;
                case "38":
                    game.SetDirection(Direction.Up);
                    break;
                case "39":
                    game.SetDirection(Direction.Right);
                    break;
                case "40":
                    game.SetDirection(Direction.Down);
                    break;
                default:
                    break;
            }
        }
    }
}
