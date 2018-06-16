namespace PacMan.Interfaces
{
    public interface IMovable:ICoord
    {
        void StartPosition();
        bool MoveLeft(int[,] map);
        bool MoveRight(int[,] map);
        bool MoveUp(int[,] map);
        bool MoveDown(int[,] map);
    }
}
