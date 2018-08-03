using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Inky : Ghost
    {
        public Inky(Map map, Position start) : base(map, start)
        {
            StrategyGoToCorner();

            id = "inky";
            idchar = 'I';
        }

        public override void StrategyGoToCorner() => Strategy = new GoToCornerForInky();

        public override void DefaultCoord()
        {
            homePosition = new Position(Map.Widht - 4, Map.Height - 5);
            base.DefaultCoord();
        }

        public override bool Move()
        {
            if (Position == homePosition && Strategy is GoToCornerForInky)
            {
                Strategy = new GoToClockwise();
            }
            return base.Move();
        }
    }
}
