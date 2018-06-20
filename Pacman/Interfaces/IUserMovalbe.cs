namespace PacMan.Interfaces
{
    public interface IUserMovalbe: IMovable
    {
        bool Move(Direction direction, ICoord[,] map);
    }
}
