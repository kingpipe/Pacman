using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using PacMan;
using PacmanWeb.Data;
using PacmanWeb.Models;
using PacmanWeb.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace PacmanWeb.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private IConfiguration Configuration { get; }
        private GameCollection GameCollection { get; }
        private ApplicationDbContext Context { get; }
        private IHubContext<PacmanHub> HubContext { get; }

        public GameController(GameCollection gameCollection, IConfiguration configuration,
            ApplicationDbContext context, IHubContext<PacmanHub> hubContext)
        {
            Configuration = configuration;
            GameCollection = gameCollection;
            Context = context;
            HubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BlueMap()
        {
            var key = User.Identity.Name;
            var game = new Game(Configuration.GetSection("AppConfig:MapBluePath").Value, "BlueMap");
            GameCollection.AddGame(key, new ConnectionGame(game, HubContext, key, Context));
            var info = new InformationModel { Widht = game.Map.Widht, Height = game.Map.Height, Id = key };
            return View(info);
        }

        public IActionResult GreenMap()
        {
            var key = User.Identity.Name;
            var game = new Game(Configuration.GetSection("AppConfig:MapGreenPath").Value, "GreenMap");
            GameCollection.AddGame(key, new ConnectionGame(game, HubContext, key, Context));
            var info = new InformationModel { Widht = game.Map.Widht, Height = game.Map.Height, Id = key };
            return View(info);
        }

        public IActionResult RedMap()
        {
            var key = User.Identity.Name;
            var game = new Game(Configuration.GetSection("AppConfig:MapRedPath").Value, "RedMap");
            GameCollection.AddGame(key, new ConnectionGame(game, HubContext, key, Context));
            var info = new InformationModel { Widht = game.Map.Widht, Height = game.Map.Height, Id = key };
            return View(info);
        }

        [AllowAnonymous]
        public IActionResult Records()
        {
            return View(Context.Records.OrderByDescending(model => model.Score));
        }
    }
}