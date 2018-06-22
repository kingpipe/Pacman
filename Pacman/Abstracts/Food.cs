using PacMan.Interfaces;


namespace PacMan.Abstracts
{
    abstract public class Food: IFood
    {
        public Position Position { get; set; }
        public int Score { get; set; }
        public bool IsLive { get; set; }

        public Food(IPosition position)
        {
            IsLive = true;
        }
    }
}
