using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PacMan.Enums;
using PacmanWeb.Models;

namespace PacmanWeb.Hubs
{
    public class PacmanHub : Hub
    {
        private readonly GameCollection gamecollection;
        
        public PacmanHub(GameCollection gamecollection)
        {
            this.gamecollection = gamecollection;
        }

        public void Start(string id)
        {
            gamecollection[id].Start();
        }

        public void Stop(string id)
        {
            gamecollection[id].Stop();
        }

        public void Restart(string id)
        {
            gamecollection[id].Default();
            gamecollection[id].Start();
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
            Clients.Caller.SendAsync("add");
            return base.OnConnectedAsync();
        }

        public async Task AddInGroup(string id)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, id);
        }
    }
}