namespace PacMan.Interfaces
{
    interface IMovable : ICoord, IStartCoord, ISinkMoving
    {
        bool Move();
    }
}
