namespace PacMan.Interfaces
{
    public interface IFood
    {
        IPosition position { get; set; }

        int Score { get; set; }

        bool IsLive { get; set; }

    }
}
