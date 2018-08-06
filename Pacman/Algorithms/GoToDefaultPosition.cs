using System.Collections.Generic;
using PacMan.Interfaces;

namespace PacMan.Algorithms
{
    class GoToDefaultPosition : IStrategy
    {
        private readonly IStrategy strategy;

        public GoToDefaultPosition()
        {
            strategy = new AstarAlgorithmOptimization();
        }

        public Stack<Position> FindPath(IMap map, Position start, Position goal)
        {
            return strategy.FindPath(map, start, goal);
        }
    }
}
