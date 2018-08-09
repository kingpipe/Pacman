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
        private GameCollection gamecollection;
        private readonly PacmanHubContext pacmanHubContext;
        private readonly ApplicationDbContext context;

        public PacmanHub(GameCollection gamecollection, PacmanHubContext pacmanHubContext, ApplicationDbContext context)
        {
            this.gamecollection = gamecollection;
            this.pacmanHubContext = pacmanHubContext;
            this.context = context;
        }

        public void Start(string id)
        {
            gamecollection[id].AddHandler(pacmanHubContext.Move, pacmanHubContext.ChangeScore,
             pacmanHubContext.UpdateMap);
            gamecollection[id].Start();
        }

        public void Stop(string id)
        {
            gamecollection[id].Stop();
            Task.Run(() => pacmanHubContext.UpdateMap());
        }

        public void Restart(string id)
        {
            gamecollection[id].Default();
            gamecollection[id].Start();
            Task.Run(() => pacmanHubContext.UpdateMap());
        }

        public async Task AddinDB(string id)
        {
            await context.Records.AddAsync(
                new RecordsModel
                {
                    Level = gamecollection[id].Level,
                    Name = id,
                    Score = gamecollection[id].Score,
                    Time = DateTime.Now,
                    Map = gamecollection[id].Map.Name
                });
            await context.SaveChangesAsync();
        }

        public void PacmanDirection(string direction, string id)
        {
            switch (direction)
            {
                case "37":
                    gamecollection[id].SetDirection(Direction.Left);
                    break;
                case "38":
                    gamecollection[id].SetDirection(Direction.Up);
                    break;
                case "39":
                    gamecollection[id].SetDirection(Direction.Right);
                    break;
                case "40":
                    gamecollection[id].SetDirection(Direction.Down);
                    break;
                default:
                    break;
            }
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}