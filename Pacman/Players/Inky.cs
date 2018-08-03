using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Inky : Ghost
    {
        public Inky(Map map, Position start) : base(map, start)
        {
            StrategyRandom();

            id = "inky";
            idchar = 'I';
        }

        public override void StrategyRandom() => Strategy = new GoToCornerForInky();

        public override void StartPosition()
        {
            homePosition = new Position(Map.Widht - 4, Map.Height - 5);
            base.StartPosition();
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
