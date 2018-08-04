using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Pinky : Ghost
    {
        public override Position StartCoord
        {
            get => base.StartCoord;
            set
            {
                homePosition = new Position(3, 1);
                base.StartCoord = value;
            }
        }

        public Pinky(Map map, Position start) : base(map, start)
        {
            StrategyGoToCorner();

            GoToCircle = new GoAgainstClockwise();

            id = "pinky";
            idchar = 'N';
        }
    }
}
