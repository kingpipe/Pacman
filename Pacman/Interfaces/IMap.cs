namespace PacMan.Interfaces
{
    interface IMap : ISize
    {
        ICoord[,] map { get; set; }
        bool OnMap(IPosition position);
        ICoord this[IPosition index] { get; set; }
    }
}
