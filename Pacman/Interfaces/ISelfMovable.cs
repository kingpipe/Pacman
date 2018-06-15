namespace PacMan.Interfaces
{
    public interface ISelfMovable: IMovable
    {
        bool Move(int[,] map);
    }
}
