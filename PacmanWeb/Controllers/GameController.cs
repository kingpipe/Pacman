﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PacmanWeb.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DefaultMap()
        {
            return View();
        }

        public IActionResult BigMap()
        {
            return View();
        }
    }
}