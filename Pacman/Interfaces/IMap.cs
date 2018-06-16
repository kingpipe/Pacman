
namespace PacMan.Interfaces
{
    public interface IMap:ISize
    {
        int[,] map { get; set; }
    }
}
