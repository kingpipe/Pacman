namespace PacMan.Interfaces
{
    interface IGhost: IMovable, IFood
    {
        void Restart();
        bool Frightened { get; set; }
        Position PacmanPosition { get; set; }
    }
}
