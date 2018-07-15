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

        public FilterToInitMap(IHubContext<PacmanHub> hubContext,IHostingEnvironment hostingEnvironment)
        {
            this.hubContext = hubContext;
            var path = hostingEnvironment.ContentRootPath;
            var allpath = Path.Combine(path + "\\wwwroot" + "\\map.txt");
            this.hubContext = hubContext;
            game = new Game(allpath, new Size(30, 31));
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            game.AddMoveHandlerToGhosts(Move);
            game.AddMoveHandlerToPacman(Move);
            Thread.Sleep(10000);
            game.Start();
        }

        private void Move(ICoord coord)
        {
            hubContext.Clients.All.SendAsync("Init", coord.Position.X, coord.Position.Y, coord.GetId());
        }

        private async void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            await InitMap();
            ((System.Timers.Timer)sender).Stop();
        }

        private async Task InitMap()
        {
            ICoord[,] array = game.Map.map;
            for (int y = 0; y < game.Map.Height; y++)
            {
                for (int x = 0; x < game.Map.Width; x++)
                {
                    await InitCoord(array[x, y]);
                }
            }
        }

        private async Task InitCoord(ICoord coord)
        {
            await hubContext.Clients.All.SendAsync("Init", coord.Position.X, coord.Position.Y, coord.GetId());
            await Task.Delay(1);
        }
    }
}
