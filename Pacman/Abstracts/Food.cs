using PacMan.Interfaces;

namespace PacMan.Abstracts
{
    abstract public class Food: IFood
    {
        public abstract char GetCharElement();

        public Position Position { get; set; }
        public int Score { get; set; }
        public bool IsLive { get; set; }

        public Food()
        { }

        public Food(Position position)
        {
            Position = position;
            IsLive = true;
        }
    }
}
