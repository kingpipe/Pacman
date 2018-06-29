namespace PacMan.Interfaces
{
    interface IFood:ICoord
    {
        int Score { get; set; }

        bool IsLive { get; set; }

    }
}
