using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PacMan.Interfaces;
using PacmanWeb.Models;

namespace PacmanWeb.Hubs
{
    public class PacmanHubContext
    {
        private readonly IHubContext<PacmanHub> hubContext;
        private GameCollection gamecollection;

        public PacmanHubContext(IHubContext<PacmanHub> hubContext, GameCollection gamecollection)
        {
            this.hubContext = hubContext;
            this.gamecollection = gamecollection;
        }

        public void UpdateMap()
        {
            hubContext.Clients.All.SendAsync("DrawMap", gamecollection["fedyushko1@gmail.com"].Map.GetArrayID());
            hubContext.Clients.All.SendAsync("Level", gamecollection["fedyushko1@gmail.com"].Level);
            hubContext.Clients.All.SendAsync("Live", gamecollection["fedyushko1@gmail.com"].Lives);
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
            Task.Run(() => hubContext.Clients.All.SendAsync("Score", gamecollection["fedyushko1@gmail.com"].Score));
        }
    }
}
