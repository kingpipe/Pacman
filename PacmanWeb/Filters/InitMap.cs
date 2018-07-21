using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacmanWeb.MenagerPacman;

namespace PacmanWeb.Filters
{
    public class InitMap: Attribute, IResultFilter
    {

        private readonly IHubContext<PacmanHub> hubContext;
        private readonly Game game;

        public InitMap(IHubContext<PacmanHub> hubContext, Game game)
        {
            this.hubContext = hubContext;
            this.game = game;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            hubContext.Clients.All.SendAsync("DrawMap", game.Map.GetArrayID());
        }

        public void OnActionExecuting(ActionExecutingContext context)
        { }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            hubContext.Clients.All.SendAsync("DrawMap", game.Map.GetArrayID());
        }

        public void OnResultExecuting(ResultExecutingContext context)
        { }
    }
}
