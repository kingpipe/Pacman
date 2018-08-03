using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Pinky : Ghost
    {
        public Pinky(Map map, Position start) : base(map, start)
        {
            StrategyRandom();

            id = "pinky";
            idchar = 'N';
        }

        public override void StrategyRandom() => Strategy = new GoToCornerForPinky();

        public override void StartPosition()
        {
            homePosition = new Position(3, 1);
            base.StartPosition();
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
