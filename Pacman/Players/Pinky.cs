using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Pinky : Ghost
    {
        public Pinky(Map map, Position start) : base(map, start)
        {
            id = "pinky";
            idchar = 'N';
        }

        public override void StrategyRandom() => Strategy = new GoAgainstClockwise();
    }
}
