using PacMan.Interfaces;

namespace PacMan.Abstracts
{
    abstract class Food: IFood
    {
        public abstract char GetCharElement();
        public abstract string GetId();

        public Position Position { get; set; }
        public int Score { get; set; }
        public bool IsLive { get; set; }

        protected Food()
        { }

        protected Food(Position position)
        {
            Position = position;
            IsLive = true;
        }
    }
}
