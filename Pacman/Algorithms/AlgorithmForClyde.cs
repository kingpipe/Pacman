using System;
using System.Collections.Generic;
using System.Linq;
using PacMan.Interfaces;

namespace PacMan.Algorithms
{
    class AlgorithmForClyde : IStrategy
    {
        public Stack<Position> FindPath(IMap map, Position start, Position goal)
        {
            Stack<Position> path = new Stack<Position>();
            Dictionary<Position, int> position_and_distance = new Dictionary<Position, int>();
            Position[] neighbourPoints = new Position[4];

            neighbourPoints[0] = new Position(start.X + 1, start.Y);
            neighbourPoints[1] = new Position(start.X - 1, start.Y);
            neighbourPoints[2] = new Position(start.X, start.Y + 1);
            neighbourPoints[3] = new Position(start.X, start.Y - 1);

            foreach (var point in neighbourPoints)
            {
                if (point.X < 0 || point.X >= map.Widht)
                    continue;
                if (point.Y < 0 || point.Y >= map.Height)
                    continue;
                if (map[point] is Wall || map[point] is IGhost)
                    continue;
                position_and_distance.Add(point, Math.Abs(point.X - goal.X) + Math.Abs(point.Y - goal.Y));
            }

            if (position_and_distance.Count != 0)
            {
                double min = position_and_distance.Values.Min();

                foreach (var collection in position_and_distance)
                {
                    if (collection.Value == min)
                    {
                        path.Push(collection.Key);
                        return path;
                    }
                }
            }
            return path;
        }
    }
}
