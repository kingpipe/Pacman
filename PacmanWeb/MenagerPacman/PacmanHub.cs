using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacMan.Enums;
using PacMan.Interfaces;

namespace PacmanWeb.MenagerPacman
{
    public class PacmanHub : Hub
    {
        private readonly Game game;
        private readonly IHubContext<PacmanHub> hubContext;

        public PacmanHub(Game game, IHubContext<PacmanHub> hubContext)
        {
            this.game = game;
            this.hubContext = hubContext;
        }

        public void Start()
        {
            if (game.Status == GameStatus.ReadyToStart)
            {
                Task.Run(() => UpdateMap());
                game.AddMoveHandlerToGhosts(Move);
                game.AddMoveHandlerToPacman(PacmanMove);
                game.PacmanIsDied += Game_PacmanIsDied;
                game.UpdateMap += UpdateMap;
                game.Start();

            }
            else if (game.Status == GameStatus.Stop)
            {
                game.Start();
            }
        }

        public void Stop()
        {
            if (game.Status == GameStatus.InProcess)
            {
                game.Stop();
            }
            Task.Run(() => UpdateMap());
        }

        public void Restart()
        {
            game.Restart();
            Task.Run(() => UpdateMap());
            Task.Run(() => hubContext.Clients.All.SendAsync("PacmanIsKilled", game.Lives));
        }

        public void PacmanDirection(string direction)
        {
            switch (direction)
            {
                case "37":
                    game.SetDirection(Direction.Left);
                    break;
                case "38":
                    game.SetDirection(Direction.Up);
                    break;
                case "39":
                    game.SetDirection(Direction.Right);
                    break;
                case "40":
                    game.SetDirection(Direction.Down);
                    break;
                default:
                    break;
            }
        }

        private void Game_PacmanIsDied()
        {
            game.Stop();
            Task.Run(() => UpdateMap());
            Task.Run(() => hubContext.Clients.All.SendAsync("PacmanIsKilled", game.Lives));
        }

        private void UpdateMap()
        {
            hubContext.Clients.All.SendAsync("Map",
                game.Map.GetArrayPositionX(),
                game.Map.GetArrayPositionY(),
                game.Map.GetArrayID(),
                game.Level);
        }

        private void Move(ICoord coord)
        {
            Task.Run(() => hubContext.Clients.All.SendAsync("Move",
                coord.Position.X,
                coord.Position.Y,
                coord.GetId()));
        }

        private void PacmanMove(ICoord coord)
        {
            string direction;
            switch (game.Direction)
            {
                case Direction.Right:
                    direction = "right";
                    break;
                case Direction.Left:
                    direction = "left";
                    break;
                case Direction.Up:
                    direction = "up";
                    break;
                case Direction.Down:
                    direction = "down";
                    break;
                default:
                    direction = "";
                    break;
            }
            Task.Run(() => hubContext.Clients.All.SendAsync("PacmanMove",
                coord.Position.X,
                coord.Position.Y,
                coord.GetId() + direction,
                game.Score));
        }
    }
}