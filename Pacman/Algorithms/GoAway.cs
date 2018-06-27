using System.Collections.Generic;
using PacMan.Interfaces;
using PacMan.Algorithms.Astar;

namespace PacMan.Algorithms
{
    class GoAway : IStrategy
    {
        private IStrategy astar = new AstarAlgorithm();
        public Stack<Position> FindPath(IMap map, Position start, Position goal)
        {
            if (goal.X < map.Width / 2 && goal.Y < map.Height / 2)
                goal = new Position(map.Width - 2, map.Height - 1);
            if (goal.X >= map.Width / 2 && goal.Y < map.Height / 2)
                goal = new Position(map.Width - 2, 1);
            if (goal.X < map.Width / 2 && goal.Y >= map.Height / 2)
                goal = new Position(2, map.Height - 1);
            if (goal.X >= map.Width / 2 && goal.Y >= map.Height / 2)
                goal = new Position(2, 1);
            return astar.FindPath(map, start, goal);
        }
    }
}
