using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacMan.Enums;
using PacmanWeb.Data;
using PacmanWeb.Models;

namespace PacmanWeb.Hubs
{
    public class PacmanHub : Hub
    {
        private Game game;
        private readonly PacmanHubContext pacmanHubContext;
        private readonly ApplicationDbContext context;

        public PacmanHub(Game game, PacmanHubContext pacmanHubContext, ApplicationDbContext context)
        {
            this.game = game;
            this.pacmanHubContext = pacmanHubContext;
            this.context = context;
        }

        public void Start()
        {
            game.Start();
        }

        public void Stop()
        {
            game.Stop();
            Task.Run(() => pacmanHubContext.UpdateMap());
        }

        public void Restart()
        {
            game.Default();
            game.Start();
            Task.Run(() => pacmanHubContext.UpdateMap());
        }

        public async Task AddinDB()
        {
            await context.Records.AddAsync(
                new RecordsModel
                {
                    Level = game.Level,
                    Name = Context.User.Identity.Name,
                    Score = game.Score,
                    Time = DateTime.Now,
                    Map = game.Map.Name
                });
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

        public override Task OnConnectedAsync()
        {
            game.AddHandler(pacmanHubContext.Move, pacmanHubContext.ChangeScore,
                pacmanHubContext.UpdateMap);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            game.Default();
            return base.OnDisconnectedAsync(exception);
        }
    }
}