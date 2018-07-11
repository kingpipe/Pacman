using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Foods
{
    class Energizer : Food, IGetChar
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

        public override string GetId()
        {
            return "energizer";
        }
    }
}
