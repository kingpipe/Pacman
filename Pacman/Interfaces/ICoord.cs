namespace PacMan.Interfaces
{
    public interface ICoord : IGetChar, IGetId
    {
        Position Position { get; set; }
    }
}
