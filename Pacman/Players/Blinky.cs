using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Blinky : Ghost
    {
        public Blinky(Map map, Position start) : base(map, start)
        {
            StrategyGoToCorner();

            id = "blinky";
            idchar = 'B';
        }

        public override void StrategyGoToCorner() => Strategy = new GoToCornerForBlinky();

        public override void DefaultCoord()
        {
            homePosition = new Position(Map.Widht - 4, 1);
            base.DefaultCoord();
        }

        public override bool Move()
        {
            if (Position == homePosition && Strategy is GoToCornerForBlinky)
            {
                Strategy = new GoToClockwise();
            }
            return base.Move();
        }
    }
}
