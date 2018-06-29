namespace PacMan.Interfaces
{
    interface IGhost: IMovable
    {
        bool Frightened { get; set; }
    }
}
