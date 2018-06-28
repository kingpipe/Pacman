using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Foods
{
    public class LittleGoal: Food, IGetChar
    {
        public LittleGoal(Position position) : base(position)
        {
            Position = position;
            Score = 10;
        }

        public char GetCharElement()
        {
            return (char)183;
        }
    }
}
