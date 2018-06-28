using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Foods
{
    public class Cherry:Food, IGetChar
    {
        public Cherry(Position position) : base(position)
        {
            Position = position;
            Score = 100;
        }

        public char GetCharElement()
        {
            return 'A';
        }
    }
}
