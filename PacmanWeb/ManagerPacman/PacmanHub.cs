using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacMan.Interfaces;

namespace PacmanWeb.ManagerPacman
{
    public class PacmanHub : Hub
    {
        public Game Game { get; set; }

        public PacmanHub(Game game)
        {
            Game = game;
        }
        public void Start()
        {
            Game.AddMoveHandlerToGhosts(HandlerToPlayers);
            Game.AddMoveHandlerToPacman(HandlerToPlayers);
            Game.Start();
        }
         
        public async void HandlerToPlayers(ICoord obj)
        {
           await  Clients.Caller.SendAsync("EventToPlayer", obj.Position.X, obj.Position.Y, obj.GetId());
        }

    }
}