using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Pinky : Ghost
    {
        public Pinky(Position start, Map map) : base(start, map)
        {
            Id = "pinky";
            idchar = 'N';

            homePosition = new Position(3, 1);
        }
        public override void StrategyRunForPacman() => Strategy = new AstarAlgorithmOptimization();
        protected override void GoToCircle() => Strategy = new GoAgainstClockwise();
    }
}
