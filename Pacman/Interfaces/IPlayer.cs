namespace PacMan.Interfaces
{
    public interface IPlayer
    {
        bool MoveLeft(int[,] map);
        bool MoveRight(int[,] map);
        bool MoveUp(int[,] map);
        bool MoveDown(int[,] map);
    }
}
