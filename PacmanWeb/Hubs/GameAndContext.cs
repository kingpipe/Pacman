using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacMan.Interfaces;

namespace PacmanWeb.Hubs
{
    public class GameAndContext
    {
        public Game game;
        private IHubContext<PacmanHub> hubContext;
        private string key;

        public GameAndContext(Game game, IHubContext<PacmanHub> hubContext, string key)
        {
            this.game = game;
            this.hubContext = hubContext;
            this.key = key;
            game.AddHandler(Move, ChangeScore, UpdateMap);
        }

        public void UpdateMap()
        {
            hubContext.Clients.Groups(key).SendAsync("DrawMap", game.Map.GetArrayID());
            hubContext.Clients.Groups(key).SendAsync("Level", game.Level);
            hubContext.Clients.Groups(key).SendAsync("Live", game.Lives);
        }

        public void Move(ICoord coord)
        {
            Task.Run(() => hubContext.Clients.Groups(key).SendAsync("Move",
                coord.Position.X,
                coord.Position.Y,
                coord.GetId()));
        }

        public void ChangeScore()
        {
            Task.Run(() => hubContext.Clients.Groups(key).SendAsync("Score", game.Score));
        }
    }
}
