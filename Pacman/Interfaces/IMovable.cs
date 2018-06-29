namespace PacMan.Interfaces
{
    public interface IMovable : ICoord, IStartPosition
    {
        bool MoveLeft();
        bool MoveRight();
        bool MoveUp();
        bool MoveDown();
        bool Move();
    }
}
