
namespace PacMan.Interfaces
{
    public interface IMap : ISize
    {
        ICoord[,] map { get; set; }

        bool OnBoard(IPosition position);
    }
}
