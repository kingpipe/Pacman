using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Foods
{
    public class BigGoal : Food
    {
        public BigGoal(IPosition position):base(position)
        {
            Score = 50;
        }

        public static char GetCharElement()
        {
            return 'E';
        }

        public static int GetNumberElement()
        {
            return 3;
        }
    }
}
