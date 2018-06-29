namespace PacMan.Interfaces
{
    public interface IPacman : IMovable
    {
        int Lives { get; set; }
        int Count { get; set; }
        Direction direction { get; set; }
    }
}
