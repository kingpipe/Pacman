using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacMan.Interfaces;

namespace PacmanWeb.Hubs
{
    public class ConnectionGame
    {
        public Game Game { get; private set; }
        private readonly IHubContext<PacmanHub> _hubContext;
        private readonly string _id;

        public ConnectionGame(Game game, IHubContext<PacmanHub> hubContext, string id)
        {
            Game = game;
            _hubContext = hubContext;
            _id = id;
            game.AddHandler(Move, ChangeScore, UpdateMap);
        }

        private async void UpdateMap()
        {
            await _hubContext.Clients.Groups(_id).SendAsync("DrawMap", Game.Map.GetArrayID(), Game.Level, Game.Lives);
        }

        private async void Move(ICoord coord)
        {
            await _hubContext.Clients.Groups(_id).SendAsync("Move",
                coord.Position.X,
                coord.Position.Y,
                coord.GetId());
        }

        private async void ChangeScore()
        {
            await _hubContext.Clients.Groups(_id).SendAsync("Score", Game.Score);
        }
    }
}
