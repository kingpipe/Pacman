using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacMan.Interfaces;
using PacmanWeb.Hubs;

namespace PacmanWeb.Models.GameModels
{
    public class GameConnection
    {
        public Game Game { get; private set; }
        private readonly IHubContext<PacmanHub> _hubContext;
        private readonly string _id;

        public GameConnection(Game game, IHubContext<PacmanHub> hubContext, string id)
        {
            Game = game;
            _hubContext = hubContext;
            _id = id;
            game.AddHandler(MoveAsync, ChangeScoreAsync, UpdateMapAsync);
        }

        private async Task UpdateMapAsync()
        {
            await _hubContext.Clients.Groups(_id).SendAsync("DrawMap", Game.Map.GetArrayID(), Game.Level, Game.Lives);
        }

        private async Task MoveAsync(ICoord coord)
        {
            await _hubContext.Clients.Groups(_id).SendAsync("Move",
                coord.Position.X,
                coord.Position.Y,
                coord.GetId());
        }

        private async Task ChangeScoreAsync()
        {
            await _hubContext.Clients.Groups(_id).SendAsync("Score", Game.Score);
        }
    }
}
