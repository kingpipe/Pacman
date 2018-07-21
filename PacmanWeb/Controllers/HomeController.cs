using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacmanWeb.Data;
using PacmanWeb.Filters;
using PacmanWeb.MenagerPacman;
using PacmanWeb.Models;

namespace PacmanWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<PacmanHub> hubContext;
        private readonly Game game;
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> user;

        public HomeController(IHubContext<PacmanHub> hubContext, Game game, ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            this.hubContext = hubContext;
            this.game = game;
            this.context = context;
            this.user = user;
        }

        public IActionResult Index()
        {
            var users = context.Users.ToList();
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

        [Authorize]
        [ServiceFilter(typeof(InitMap))]
        public IActionResult Map()
        {
            return View();
        }

        public IActionResult Records()
        {
            return View(context.Records.ToList());
        }
    }
}