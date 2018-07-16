using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacMan.Interfaces;
using PacmanWeb.ManagerPacman;

namespace PacmanWeb.Filters
{
    public class FilterToInitMap : Attribute, IResultFilter
    {
        public readonly IHubContext<PacmanHub> hubContext;
        public readonly Game game;

        public FilterToInitMap(IHubContext<PacmanHub> hubContext, Game game)
        {
            this.hubContext = hubContext;
            this.game = game;
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var timer = new System.Timers.Timer(2000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }


        private async void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            await InitMap();
            ((System.Timers.Timer)sender).Stop();
        }

        private async Task InitMap()
        {
            await hubContext.Clients.All.SendAsync("Init");
        }

    }
}
