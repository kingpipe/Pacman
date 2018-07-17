using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacMan.Interfaces;

namespace PacmanWeb.ManagerPacman
{
    public class PacmanHub : Hub
    {
        private readonly Game game;

        public PacmanHub(Game game)
        {
            this.game = game;
        }

        private void Game_PacmanIsDied()
        {
        }

        public void Start()
        {
            Task.Run(() => Update());
            game.AddMoveHandlerToGhosts(Move);
            game.AddMoveHandlerToPacman(Move);
            game.Start();
        }

        public void Stop()
        {
            game.Stop();
        }

        private void Move(ICoord coord)
        {
            Clients.All.SendAsync("Move", coord.Position.X, coord.Position.Y, coord.GetId());
        }

        public void Update()
        {
            Task.Run(() => Clients.All.SendAsync("Init"));
        }
    }
}