using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Pinky : Ghost
    {
        public override Position StartCoord
        {
            get => base.StartCoord;
            set
            {
                base.StartCoord = value;
                homePosition = new Position(3, 1);
            }
        }

        public Pinky(Position start, Map map) : base(start, map)
        {
            id = "pinky";
            idchar = 'N';
        }
        public override void StrategyRunForPacman() => Strategy = new AstarAlgorithmOptimization();
        protected override void GoToCircle() => Strategy = new GoAgainstClockwise();
    }
}
