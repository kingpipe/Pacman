using PacMan.Interfaces;

namespace PacMan.Abstracts
{
    abstract class Food : IFood
    {
        public Position Position { get; set; }
        public int Score { get; set; }
        public bool IsLive { get; set; }

        protected string id;
        protected char idchar;

        protected Food(Position position)
        {
            Position = position;
            IsLive = true;
        }

        public char GetCharElement() => idchar;
        public string GetId() => id;
    }
}
