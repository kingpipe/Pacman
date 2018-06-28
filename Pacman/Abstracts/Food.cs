using PacMan.Interfaces;

namespace PacMan.Abstracts
{
    abstract public class Food: IFood
    {
        public Position Position { get; set; }
        public int Score { get; set; }
        public bool IsLive { get; set; }

        public Food(Position position)
        {
            IsLive = true;
        }

        public virtual char GetCharElement()
        {
            throw new System.NotImplementedException();
        }
    }
}
