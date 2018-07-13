using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace PacmanWeb.ManagerPacman
{
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await Clients.Caller.SendAsync("Send", message);
        }
    }
}
