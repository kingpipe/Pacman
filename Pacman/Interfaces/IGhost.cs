namespace PacMan.Interfaces
{
    public interface IGhost: ISelfMovable
    {
        bool Frightened { get; set; }
    }
}
