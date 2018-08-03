
namespace PacMan.Interfaces
{
    interface IGhost: IMovable
    {
        void Died();
        bool Frightened { get; set; }
        Position PacmanPosition { get; set; }
    }
}
