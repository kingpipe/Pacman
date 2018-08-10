using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacMan.Interfaces;
using PacmanWeb.Data;
using PacmanWeb.Models;

namespace PacmanWeb.Hubs
{
    public class ConnectionGame
    {
        public Game Game { get; private set; }
        private readonly IHubContext<PacmanHub> hubContext;
        private readonly string key;
        private readonly ApplicationDbContext context;

        public ConnectionGame(Game game, IHubContext<PacmanHub> hubContext, 
            string key, ApplicationDbContext context)
        {
            Game = game;
            this.context = context;
            this.hubContext = hubContext;
            this.key = key;
            game.AddHandler(Move, ChangeScore, UpdateMap, TheEnd);
        }

        private void UpdateMap()
        {
            hubContext.Clients.Groups(key).SendAsync("DrawMap", Game.Map.GetArrayID());
            hubContext.Clients.Groups(key).SendAsync("Level", Game.Level);
            hubContext.Clients.Groups(key).SendAsync("Live", Game.Lives);
        }

        private void Move(ICoord coord)
        {
            Task.Run(() => hubContext.Clients.Groups(key).SendAsync("Move",
                coord.Position.X,
                coord.Position.Y,
                coord.GetId()));
        }

        private void ChangeScore()
        {
            Task.Run(() => hubContext.Clients.Groups(key).SendAsync("Score", Game.Score));
        }

        private async Task TheEnd()
        {
            await context.Records.AddAsync(
                new RecordsModel
                {
                    Level = Game.Level,
                    Name = key,
                    Score = Game.Score,
                    Time = DateTime.Now,
                    Map = Game.Map.Name
                });
            await context.SaveChangesAsync();
        }
    }
}
