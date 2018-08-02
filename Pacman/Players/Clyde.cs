using PacMan.Abstracts;
using PacMan.Algorithms;

namespace PacMan.Players
{
    class Clyde : Ghost
    {
        public Clyde(Map map, Position start) : base(map, start)
        {
            id = "clyde";
            idchar = 'C';
        }
        
        public override void StrategyRunForPacman() => Strategy = new AlgorithmForClyde();
        public override void StrategyRandom() => Strategy = new GoAgainstClockwise();      
    }
}
