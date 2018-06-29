namespace PacMan.Interfaces
{
    interface IMovable:ICoord
    {
        void StartPosition();
        bool MoveLeft();
        bool MoveRight();
        bool MoveUp();
        bool MoveDown();
    }
}
