using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacMan.Interfaces;

namespace PacmanWeb.Hubs
{
    public class PacmanHubContext
    {
        private readonly IHubContext<PacmanHub> hubContext;
        private Game game;

        public PacmanHubContext(IHubContext<PacmanHub> hubContext, Game game)
        {
            this.hubContext = hubContext;
            this.game = game;
        }

        public void UpdateMap()
        {
            hubContext.Clients.All.SendAsync("DrawMap", game.Map.GetArrayID());
            hubContext.Clients.All.SendAsync("Level", game.Level);
            hubContext.Clients.All.SendAsync("Live", game.Lives);
        }

        public void Move(ICoord coord)
        {
            Task.Run(() => hubContext.Clients.All.SendAsync("Move",
                coord.Position.X,
                coord.Position.Y,
                coord.GetId()));
        }

        public void ChangeScore()
        {
            Task.Run(() => hubContext.Clients.All.SendAsync("Score", game.Score));
        }
    }
}
