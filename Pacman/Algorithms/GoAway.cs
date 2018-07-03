using System.Collections.Generic;
using PacMan.Interfaces;
using PacMan.Algorithms.Astar;

namespace PacMan.Algorithms
{
    class GoAway : IStrategy
    {
        private readonly IStrategy astar = new AstarAlgorithm();

        public Stack<Position> FindPath(IMap map, Position start, Position goal)
        {
            int x = map.Width / 2;
            int y = map.Height / 2;
            Position value = goal;
            
                if (goal.X < x && goal.Y < y)
                    value = new Position(map.Width - 3, map.Height - 2);
                if (goal.X >= x && goal.Y < y)
                    value = new Position(2, map.Height - 2);
                if (goal.X < x && goal.Y >= y)
                    value = new Position(map.Width - 3, 1);
                if (goal.X >= x && goal.Y >= y)
                    value = new Position(2, 1);
               
            return astar.FindPath(map, start, value);
        }
    }
}
