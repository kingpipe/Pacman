namespace PacMan.Interfaces
{
    public interface IMovable:ICoord
    {
        void StartPosition();
        bool MoveLeft();
        bool MoveRight();
        bool MoveUp();
        bool MoveDown();
    }
}
