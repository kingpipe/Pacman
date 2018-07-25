using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using PacMan;
using PacmanWeb.Data;

namespace PacmanWeb.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        public IConfiguration Configuration { get; }
        private Game Game { get; }
        private ApplicationDbContext Context { get; }

        public GameController(Game game, IConfiguration configuration, ApplicationDbContext context)
        {
            Configuration = configuration;
            Game = game;
            Context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BlueMap()
        {
            Game.SetMap(Configuration.GetSection("AppConfig:MapBluePath").Value, "BlueMap");
            return View();
        }

        public IActionResult GreenMap()
        {
            Game.SetMap(Configuration.GetSection("AppConfig:MapGreenPath").Value, "GreenMap");
            return View();
        }

        public IActionResult Records()
        {
            var query = Context.Records.ToList().OrderByDescending(e => e.Score);
            return View(query);
        }
    }
}