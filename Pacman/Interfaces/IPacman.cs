namespace PacMan.Interfaces
{
    public interface IPacman
    {
        int Lives { get; set; }
        int Count { get; set; }
        Direction direction { get; set; }

    }
}
