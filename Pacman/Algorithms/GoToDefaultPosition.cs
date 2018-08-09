using System.Collections.Generic;
using PacMan.Interfaces;

namespace PacMan.Algorithms
{
    class GoToDefaultPosition : IStrategy
    {
        private readonly IStrategy _strategy;

        public GoToDefaultPosition()
        {
            _strategy = new AstarAlgorithmOptimization();
        }

        public Stack<Position> FindPath(IMap map, Position start, Position goal)
        {
            return _strategy.FindPath(map, start, goal);
        }
    }
}
