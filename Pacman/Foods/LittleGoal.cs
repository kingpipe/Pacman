using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Foods
{
    public class LittleGoal: Food
    {
        public LittleGoal(Position position) : base(position)
        {
            Score = 10;
        }

        public static char GetCharElement()
        {
            return (char)183;
        }
    }
}
