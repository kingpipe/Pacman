using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Foods
{
    public class Empty : Food, IGetChar
    {
        public Empty()
        { }

        public Empty(Position position) : base(position)
        {
            Score = 0;
        }
        public override char GetCharElement()
        {
            return ' ';
        }
    }
}
