using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using PacMan;
using PacmanWeb.Data;
using PacmanWeb.Models;

namespace PacmanWeb.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private IConfiguration Configuration { get; }
        private GameCollection GameCollection { get; }
        private ApplicationDbContext Context { get; }

        public GameController(GameCollection gameCollection, IConfiguration configuration, ApplicationDbContext context)
        {
            Configuration = configuration;
            GameCollection = gameCollection;
            Context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BlueMap()
        {
            var key = User.Identity.Name;
            var game=new Game(Configuration.GetSection("AppConfig:MapBluePath").Value, "BlueMap");
            GameCollection.AddGame(key, game);   
            ViewBag.Width = game.Map.Widht;
            ViewBag.Height = game.Map.Height;
            ViewBag.Key = key;
            return View();
        }

        public IActionResult GreenMap()
        {
            var key = User.Identity.Name;
            var game = new Game(Configuration.GetSection("AppConfig:MapGreenPath").Value, "GreenMap");
            GameCollection.AddGame(key, game);
            ViewBag.Width = game.Map.Widht;
            ViewBag.Height = game.Map.Height;
            ViewBag.Key = key;
            return View();
        }

        public IActionResult RedMap()
        {
            var key = User.Identity.Name;
            var game = new Game(Configuration.GetSection("AppConfig:MapRedPath").Value, "RedMap");
            GameCollection.AddGame(key, game);
            ViewBag.Width = game.Map.Widht;
            ViewBag.Height = game.Map.Height;
            ViewBag.Key = key;
            return View();
        }

        [AllowAnonymous]
        public IActionResult Records()
        {
            return View(Context.Records.OrderByDescending(model => model.Score));
        }
    }
}