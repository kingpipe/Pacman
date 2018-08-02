using System.Collections.Generic;
using PacMan.Algorithms.Astar;
using PacMan.Interfaces;

namespace PacMan.Algorithms
{
    class GoToCornerForInky : IStrategy
    {
        public Stack<Position> FindPath(IMap map, Position start, Position goal)
        {
            var astar = new AstarAlgorithm();
            return astar.FindPath(map, start, new Position(map.Widht - 4, map.Height - 5));
        }
    }
}
