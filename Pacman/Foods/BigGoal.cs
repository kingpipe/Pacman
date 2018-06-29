using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Foods
{
    public class BigGoal : Food, IGetChar
    {
        public BigGoal(Position position):base(position)
        {
            Score = 50;
        }

        public override char GetCharElement()
        {
            return '*';
        }
    }
}
