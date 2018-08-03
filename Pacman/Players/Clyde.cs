using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Clyde : Ghost
    {
        public Clyde(Map map, Position start) : base(map, start)
        {
            StrategyGoToCorner();

            id = "clyde";
            idchar = 'C';
        }

        public override void StrategyRunForPacman() => Strategy = new AlgorithmForClyde();
        public override void StrategyGoToCorner() => Strategy = new GoToCornerForClyde();

        public override void DefaultCoord()
        {
            homePosition = new Position(3, Map.Height - 5);
            base.DefaultCoord();
        }

        public override bool Move()
        {
            if (Position == homePosition && Strategy is GoToCornerForClyde)
            {
                Strategy = new GoAgainstClockwise();
            }
            return base.Move();
        }
    }
}
