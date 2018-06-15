using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Foods
{
    public class LittleGoal: Food
    {
        public LittleGoal(IPosition position) : base(position)
        {
            Score = 10;
        }

        public static char GetCharElement()
        {
            return (char)183;
        }

        public static int GetNumberElement()
        {
            return 2;
        }
    }
}
