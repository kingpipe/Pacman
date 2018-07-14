using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PacMan;
using PacMan.Interfaces;

namespace PacmanWeb.ManagerPacman
{
    public class PacmanHub : Hub
    {         
        public async void HandlerToPlayers(ICoord obj)
        {
           await  Clients.Caller.SendAsync("EventToPlayer", obj.Position.X, obj.Position.Y, obj.GetId());
        }

        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Send", message);
        }
    }
}