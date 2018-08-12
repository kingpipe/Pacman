using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Clyde : Ghost
    {
        public Clyde(Position start, Map map) : base(start, map)
        {
            Id = "clyde";
            idchar = 'C';

            homePosition = new Position(3, Map.Height - 5);
        }

        public override void StrategyRunForPacman() => Strategy = new AlgorithmForClyde();
        protected override void GoToCircle() => Strategy = new GoAgainstClockwise();

    }
}
