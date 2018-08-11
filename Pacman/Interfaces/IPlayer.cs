namespace PacMan.Interfaces
{
    interface IPlayer : IMovable
    {
        Map Map{ get; set; }
        void Start();
        void Stop();
    }
}
