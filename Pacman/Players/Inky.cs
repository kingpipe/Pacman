using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Inky : Ghost
    {
        public Inky(Position start, Map map) : base(start, map)
        {
            id = "inky";
            idchar = 'I';
            homePosition = new Position(Map.Widht - 4, Map.Height - 5);
        }

        public override void StrategyRunForPacman() => Strategy = new AstarAlgorithmOptimization();
        protected override void GoToCircle() => Strategy = new GoToClockwise();
    }
}
