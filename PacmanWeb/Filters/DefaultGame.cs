using System;
using Microsoft.AspNetCore.Mvc.Filters;
using PacMan;
using PacMan.Enums;

namespace PacmanWeb.Filters
{
    public class DefaultGame : Attribute, IActionFilter
    {
        private readonly Game game;

        public DefaultGame(Game game)
        {
            this.game = game;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (game.Status != GameStatus.ReadyToStart && game.Status != GameStatus.NeedInitEvent)
            {
                game.Default();
            }
        }
    }
}
