using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacMan.Interfaces;

namespace PacmanWeb.MenagerPacman
{
    public class Drawing
    {
        private readonly IHubContext<PacmanHub> hubContext;
        private readonly Game game;

        public Drawing(IHubContext<PacmanHub> hubContext, Game game)
        {
            this.hubContext = hubContext;
            this.game = game;
            game.AddMoveHandlerToGhosts(Move);
            game.AddMoveHandlerToPacman(Move);
            game.UpdateMap += Update;
            game.PacmanIsDied += Game_PacmanIsDied;
        }

        private void Game_PacmanIsDied()
        {
        }

        public void Start()
        {
            game.Start();
        }

        public void Stop()
        {
            game.Stop();
        }

        private void Move(ICoord coord)
        {
            Task.Run(() => hubContext.Clients.All.SendAsync("Move", coord.Position.X, coord.Position.Y, coord.GetId()));
        }

        private void Update()
        {
            Task.Run(() => hubContext.Clients.All.SendAsync("Init"));
        }
    }
}