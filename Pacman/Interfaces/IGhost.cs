namespace PacMan.Interfaces
{
    interface IGhost: IMovable, IFood, ISinkAboutKillPacman
    {
        void Scared();
        void NotScared();
        void Restart();
        bool Frightened { get; set; }
        Position PacmanPosition { get; set; }
    }
}
