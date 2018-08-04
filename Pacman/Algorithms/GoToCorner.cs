using System.Collections.Generic;
using PacMan.Algorithms.Astar;
using PacMan.Interfaces;

namespace PacMan.Algorithms
{
    class GoToCorner : IStrategy
    {
        public Stack<Position> FindPath(IMap map, Position start, Position goal)
        {
            var astar = new AstarAlgorithm();
            return astar.FindPath(map, start, goal);
        }
    }
}
