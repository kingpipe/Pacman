namespace PacMan.Interfaces
{
    public interface IFood : ICoord
    {
        int Score { get; set; }
        bool IsLive { get; set; }
    }
}
