using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacMan.Enums;
using PacMan.Interfaces;
using PacmanWeb.Data;
using PacmanWeb.Models;

namespace PacmanWeb.MenagerPacman
{
    public class PacmanHub : Hub
    {
        private Game game;
        private readonly IHubContext<PacmanHub> hubContext;
        private readonly ApplicationDbContext context;

        public PacmanHub(Game game, IHubContext<PacmanHub> hubContext, ApplicationDbContext context)
        {
            this.game = game;
            this.hubContext = hubContext;
            this.context = context;
        }
        
        public void Start()
        {
            if (game.Status == GameStatus.ReadyToStart)
            {
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
            if (game.Status != GameStatus.ReadyToStart)
            {
                game.Default();
                game.Start();
                Task.Run(() => UpdateMap());
                Task.Run(() => hubContext.Clients.All.SendAsync("Live", game.Lives));
            }
        }

        public async Task AddinDB()
        {
            await context.Records.AddAsync(
                new RecordsModel {
                    Level = game.Level,
                    Name = Context.User.Identity.Name,
                    Score = game.Score,
                    Time = DateTime.Now,
                    Map =game.Map.Name });
            await context.SaveChangesAsync();
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
            Task.Run(() => hubContext.Clients.All.SendAsync("Live", game.Lives));
        }

        private void UpdateMap()
        {
            hubContext.Clients.All.SendAsync("DrawMap", game.Map.GetArrayID());
            hubContext.Clients.All.SendAsync("Level", game.Level);
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
            string direction = string.Empty;
            if (coord.GetId() == "pacman")
            {
                direction = SetDirection(direction);
            }
            Task.Run(() => hubContext.Clients.All.SendAsync("PacmanMove",
                coord.Position.X,
                coord.Position.Y,
                coord.GetId() + direction,
                game.Score));
        }

        private string SetDirection(string direction)
        {
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
                    break;
            }
            return direction;
        }
    }
}