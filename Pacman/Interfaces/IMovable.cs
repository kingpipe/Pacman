namespace PacMan.Interfaces
{
    interface IMovable : ICoord, IStartCoord
    {
        bool Move();
    }
}
