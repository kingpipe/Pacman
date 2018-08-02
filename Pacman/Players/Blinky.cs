using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Blinky : Ghost
    {
        public Blinky(Map map, Position start) : base(map, start)
        {
            id = "blinky";
            idchar = 'B';
        }

        public override void StrategyRandom() => Strategy = new GoToCornerForBlinky();

        public override void StartPosition()
        {
            homePosition = new Position(Map.Widht - 4, 1);
            base.StartPosition();
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
