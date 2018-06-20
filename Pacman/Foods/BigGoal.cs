using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Foods
{
    public class BigGoal : Food
    {
        public BigGoal(Position position):base(position)
        {
            Score = 50;
        }

        public static char GetCharElement()
        {
            return 'E';
        }
    }
}
