using System.Collections.Generic;
using PacMan.Algorithms.Astar;
using PacMan.Interfaces;

namespace PacMan.Algorithms
{
    class AstarAlgorithmOptimization : IStrategy
    {
        private Position oldposition;

        public Stack<Position> FindPath(IMap map, Position start, Position goal)
        {
            var path = new Stack<Position>();
            var freepositions = new List<Position>();

            var neibors = new List<Position>
            {
                start.Left, start.Right,
                start.Up, start.Down
            };

            foreach (var neibor in neibors)
            {
                if (map.OnMap(neibor) && !(map[neibor] is Wall) && neibor != oldposition)
                {
                    freepositions.Add(neibor);
                }
            }
            oldposition = start;

            if (freepositions.Count == 1)
            {
                path.Push(freepositions[0]);
                return path;
            }
            else
            {
                path = new AstarAlgorithm().FindPath(map, start, goal);
                return path;
            }
        }
    }
}