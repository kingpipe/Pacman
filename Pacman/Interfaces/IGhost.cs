
namespace PacMan.Interfaces
{
    interface IGhost: IMovable
    {
        void Restart();
        bool Frightened { get; set; }
        Position PacmanPosition { get; set; }
    }
}
