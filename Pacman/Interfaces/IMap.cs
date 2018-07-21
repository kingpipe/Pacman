namespace PacMan.Interfaces
{
    interface IMap : ISize
    {
        ICoord[,] map { get; set; }
        bool OnMap(IPosition position);
    }
}
