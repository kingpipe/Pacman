using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Foods
{
    public class Cherry:Food
    {
        public Cherry(Position position) : base(position)
        {
            Position = position;
            Score = 100;
        }

        public static char GetCharElement()
        {
            return 'A';
        }
    }
}
