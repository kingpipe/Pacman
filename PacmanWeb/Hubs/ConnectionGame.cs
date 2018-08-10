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
        private readonly IHubContext<PacmanHub> _hubContext;
        private readonly string _id;
        private readonly string _name;
        private readonly ApplicationDbContext _context;

        public ConnectionGame(Game game, IHubContext<PacmanHub> hubContext, 
            string id, ApplicationDbContext context, string name)
        {
            Game = game;
            _context = context;
            _hubContext = hubContext;
            _id = id;
            _name = name;
            game.AddHandler(Move, ChangeScore, UpdateMap, TheEnd);
        }

        private void UpdateMap()
        {
            _hubContext.Clients.Groups(_id).SendAsync("DrawMap", Game.Map.GetArrayID());
            _hubContext.Clients.Groups(_id).SendAsync("Level", Game.Level);
            _hubContext.Clients.Groups(_id).SendAsync("Live", Game.Lives);
        }

        private void Move(ICoord coord)
        {
            Task.Run(() => _hubContext.Clients.Groups(_id).SendAsync("Move",
                coord.Position.X,
                coord.Position.Y,
                coord.GetId()));
        }

        private void ChangeScore()
        {
            Task.Run(() => _hubContext.Clients.Groups(_id).SendAsync("Score", Game.Score));
        }

        private async Task TheEnd()
        {
            await _context.Records.AddAsync(
                new RecordsModel
                {
                    Level = Game.Level,
                    Name = _name,
                    Score = Game.Score,
                    Time = DateTime.Now,
                    Map = Game.Map.Name
                });
            await _context.SaveChangesAsync();
        }
    }
}
