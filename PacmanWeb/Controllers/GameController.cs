using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using PacMan;
using PacmanWeb.Data;
using Microsoft.EntityFrameworkCore;
using PacmanWeb.Models;

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
            ViewBag.Width = Game.Map.Widht;
            ViewBag.Height = Game.Map.Height;
            return View();
        }

        public IActionResult GreenMap()
        {
            Game.SetMap(Configuration.GetSection("AppConfig:MapGreenPath").Value, "GreenMap");
            ViewBag.Width = Game.Map.Widht;
            ViewBag.Height = Game.Map.Height;
            return View();
        }

        public IActionResult RedMap()
        {
            Game.SetMap(Configuration.GetSection("AppConfig:MapRedPath").Value, "RedMap");
            ViewBag.Width = Game.Map.Widht;
            ViewBag.Height = Game.Map.Height;
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Records()
        {
            return View(Context.Set<RecordsModel>().OrderByDescending(model => model.Score));
        }
    }
}