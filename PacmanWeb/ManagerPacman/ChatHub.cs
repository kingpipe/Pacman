using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace PacmanWeb.ManagerPacman
{
    public class ChatHub : Hub
    {
        public async Task Send(string nick, string message)
        {
            await Clients.All.SendAsync("Send", nick, message);
        }
    }
}
