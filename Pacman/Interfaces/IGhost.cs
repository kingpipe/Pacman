using System.Threading.Tasks;

namespace PacMan.Interfaces
{
    interface IGhost: IMovable
    {
        Task Restart();
        bool Frightened { get; set; }
        Position PacmanPosition { get; set; }
    }
}
