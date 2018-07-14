using System;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacmanWeb.ManagerPacman;
using PacmanWeb.Models;
using PacMan.Interfaces;

namespace PacmanWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<PacmanHub> hubContext;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly Game game;

        public HomeController(IHubContext<PacmanHub> hubContext, IHostingEnvironment hostingEnvironment)
        {
            this.hubContext = hubContext;
            this.hostingEnvironment = hostingEnvironment;
            var path = hostingEnvironment.ContentRootPath;
            var allpath = Path.Combine(path + "\\wwwroot" + "\\map.txt");
            game = new Game(allpath, new Size(30, 31));
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
            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            return View();
        }

        private async void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ICoord[,] array = game.Map.map;
            for (int y = 0; y < game.Map.Height; y++)
            {
                for (int x = 0; x < game.Map.Width; x++)
                {
                    await InitCoord(array[x, y]);
                }
            }
            ((System.Timers.Timer)sender).Stop();
        }

        private async Task InitCoord(ICoord coord)
        {
            await hubContext.Clients.All.SendAsync("Init", coord.Position.X, coord.Position.Y, coord.GetId());
            await Task.Delay(1);
        }
    }
}
