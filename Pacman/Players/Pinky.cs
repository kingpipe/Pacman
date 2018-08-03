using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Pinky : Ghost
    {
        public Pinky(Map map, Position start) : base(map, start)
        {
            StrategyGoToCorner();

            id = "pinky";
            idchar = 'N';
        }

        public override void StrategyGoToCorner() => Strategy = new GoToCornerForPinky();

        public override void DefaultCoord()
        {
            homePosition = new Position(3, 1);
            base.DefaultCoord();
        }

        public override bool Move()
        {
            if (Position == homePosition && Strategy is GoToCornerForPinky)
            {
                Strategy = new GoAgainstClockwise();
            }
            return base.Move();
        }

    }
}
