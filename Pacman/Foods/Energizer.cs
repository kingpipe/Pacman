using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Foods
{
    public class Energizer : Food, IGetChar
    {
        public Energizer()
        { }

        public Energizer(Position position):base(position)
        {
            Score = 50;
        }

        public override char GetCharElement()
        {
            return '*';
        }
    }
}
