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

        public override void StrategyRandom() => Strategy = new GoToClockwise();
    }
}
