namespace PacMan.Interfaces
{
    public interface IMovable:ICoord
    {
        void StartPosition();
        bool MoveLeft(ICoord[,] map);
        bool MoveRight(ICoord[,] map);
        bool MoveUp(ICoord[,] map);
        bool MoveDown(ICoord[,] map);
    }
}
