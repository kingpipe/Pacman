using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace PacmanWeb.ManagerPacman
{
    public class PacmanHub : Hub
    {         
        public async Task InitMap(int x, int y, string id)
        {
           await  Clients.Caller.SendAsync("InitMap", x, y, id);
        }

        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Send", message);
        }
    }
}