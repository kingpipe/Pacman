namespace PacMan.Interfaces
{
    public interface IUserMovalbe: IMovable
    {
        bool MoveLeft(int[,] map);
        bool MoveRight(int[,] map);
        bool MoveUp(int[,] map);
        bool MoveDown(int[,] map);
    }
}
