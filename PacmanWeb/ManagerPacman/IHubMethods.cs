using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace PacmanWeb.ManagerPacman
{
    public interface IHubMethods: IClientProxy
    {
        Task SendM(string message);
    }
}
