using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Clyde : Ghost
    {
        public override Position StartCoord
        {
            get => base.StartCoord;
            set
            {
                homePosition = new Position(3, Map.Height - 5);
                base.StartCoord = value;
            }
        }

        public Clyde(Map map, Position start) : base(map, start)
        {
            StrategyGoToCorner();

            GoToCircle = new GoAgainstClockwise();

            id = "clyde";
            idchar = 'C';
        }

        public override void StrategyRunForPacman() => Strategy = new AlgorithmForClyde();
    }
}
