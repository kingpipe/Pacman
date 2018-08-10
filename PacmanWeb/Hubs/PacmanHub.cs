using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PacMan.Enums;
using PacmanWeb.Data;
using PacmanWeb.Models;

namespace PacmanWeb.Hubs
{
    public class PacmanHub : Hub
    {
        private readonly GameCollection _gamecollection;
        private readonly ApplicationDbContext _context;
        
        public PacmanHub(GameCollection gamecollection, ApplicationDbContext context)
        {
            _gamecollection = gamecollection;
            _context = context;
        }

        public void Start(string id)
        {
            _gamecollection[id].Start();
        }

        public void Stop(string id)
        {
            _gamecollection[id].Stop();
        }

        public void Restart(string id)
        {
            _gamecollection[id].Default();
            _gamecollection[id].Start();
        }

        public void PacmanDirection(string direction, string id)
        {
            switch (direction)
            {
                case "37":
                    _gamecollection[id].SetDirection(Direction.Left);
                    break;
                case "38":
                    _gamecollection[id].SetDirection(Direction.Up);
                    break;
                case "39":
                    _gamecollection[id].SetDirection(Direction.Right);
                    break;
                case "40":
                    _gamecollection[id].SetDirection(Direction.Down);
                    break;
                default:
                    break;
            }
        }

        public async Task TheEnd(string id)
        {
            await _context.Records.AddAsync(
                new RecordsModel
                {
                    Level = _gamecollection[id].Level,
                    Name = Context.User.Identity.Name,
                    Score = _gamecollection[id].Score,
                    Time = DateTime.Now,
                    Map = _gamecollection[id].Map.Name
                });
            await _context.SaveChangesAsync();
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