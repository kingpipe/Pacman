namespace PacMan.Interfaces
{
    interface IGhost: ISelfMovable
    {
        bool Frightened { get; set; }
    }
}
