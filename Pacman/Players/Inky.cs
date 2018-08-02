using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Inky : Ghost
    {
        public Inky(Map map, Position start) : base(map, start)
        {
            id = "inky";
            idchar = 'I';
        }

        public override void StrategyRandom() => Strategy = new GoToClockwise();
    }
}
