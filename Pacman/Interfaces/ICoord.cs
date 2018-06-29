namespace PacMan.Interfaces
{
    public interface ICoord : IGetChar
    {
        Position Position { get; set; }
    }
}
