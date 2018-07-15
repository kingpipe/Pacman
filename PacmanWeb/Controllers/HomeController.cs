using System.IO;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacmanWeb.ManagerPacman;
using PacmanWeb.Models;
using PacmanWeb.Filters;
using PacMan.Interfaces;

namespace PacmanWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<PacmanHub> hubContext;
        private readonly IHostingEnvironment hostingEnvironment;
      //  private readonly Game game;

        public HomeController(IHubContext<PacmanHub> hubContext, IHostingEnvironment hostingEnvironment)
        {
            this.hubContext = hubContext;
            this.hostingEnvironment = hostingEnvironment;
            var path = hostingEnvironment.ContentRootPath;
            var allpath = Path.Combine(path + "\\wwwroot" + "\\map.txt");
         //   game = new Game(allpath, new Size(30, 31));
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
        [ServiceFilter(typeof(FilterToInitMap))]
        public IActionResult Map()
        {
            return View();
        }
    }
}
