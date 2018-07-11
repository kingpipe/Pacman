using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacMan.Interfaces;

namespace PacmanWeb.ManagerPacman
{
    public class PacmanHub : Hub
    {
        private Game Game { get; set; }

        public PacmanHub()
        {
            Game = new Game("", new Size(30, 31));
        }
        public void Start()
        {
            Game.AddMoveHandlerToGhosts(HandlerToPlayers);
            Game.AddMoveHandlerToPacman(HandlerToPlayers);
            Game.Start();
        }
         
        public void HandlerToPlayers(ICoord obj)
        {
            Clients.All.SendAsync("HandlerToPlayer", obj.Position.X, obj.Position.Y, obj.GetCharElement());
        }
    }
}