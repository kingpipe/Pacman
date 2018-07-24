using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PacMan;

namespace PacmanWeb.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        public IConfiguration Configuration { get; }
        private readonly Game game;

        public GameController(Game game, IConfiguration configuration)
        {
            Configuration = configuration;
            this.game = game;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BlueMap()
        {
            game.SetMap(Configuration.GetSection("AppConfig:MapBluePath").Value);
            return View();
        }

        public IActionResult GreenMap()
        {
            game.SetMap(Configuration.GetSection("AppConfig:MapGreenPath").Value);
            return View();
        }
    }
}