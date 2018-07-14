using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacmanWeb.ManagerPacman;
using PacmanWeb.Models;

namespace PacmanWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<PacmanHub> hubContext;

        public HomeController(IHubContext<PacmanHub> hubContext)
        {
            this.hubContext = hubContext;
        }
        public async Task<IActionResult> Index()
        {
            await hubContext.Clients.All.SendAsync("Map", $"Home page loaded at: {DateTime.Now}");
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
            var timer = new System.Timers.Timer(2000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            return View();
        }

        private async void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            await hubContext.Clients.All.SendAsync("Send", $"Home page loaded at: {DateTime.Now}");
        }
    }
}
