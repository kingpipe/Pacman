namespace PacMan.Interfaces
{
    interface IMovable : ICoord, IStartPosition
    {
        bool Move();
    }
}
