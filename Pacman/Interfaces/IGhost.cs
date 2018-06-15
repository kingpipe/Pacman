namespace PacMan.Interfaces
{
    public interface IGhost: ISelfMovable, IEateble
    {
        bool Frightened { get; set; }
    }
}
