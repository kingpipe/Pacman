using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PacMan.Algorithms.Astar
{
    class Algorithm
    {
        public List<Position> FindPath(int[,] map, Position start, Position goal)
        {
            // Шаг 1.
            var closedSet = new Collection<PathNode>();
            var openSet = new Collection<PathNode>();
            // Шаг 2.
            PathNode startNode = new PathNode()
            {
                position = start,
                CameFrom = null,
                PathLengthFromStart = 0,
                HeuristicEstimatePathLength = GetHeuristicPathLength(start, goal)
            };
            openSet.Add(startNode);
            while (openSet.Count > 0)
            {
                // Шаг 3.
                var currentNode = openSet.OrderBy(node =>
                  node.EstimateFullPathLength).First();
                // Шаг 4.
                if (currentNode.position == goal)
                    return GetPathForNode(currentNode);
                // Шаг 5.
                openSet.Remove(currentNode);
                closedSet.Add(currentNode);
                // Шаг 6.
                foreach (var neighbourNode in GetNeighbours(currentNode, goal, map))
                {
                    // Шаг 7.
                    if (closedSet.Count(node => node.position == neighbourNode.position) > 0)
                        continue;
                    var openNode = openSet.FirstOrDefault(node =>
                      node.position == neighbourNode.position);
                    // Шаг 8.
                    if (openNode == null)
                        openSet.Add(neighbourNode);
                    else
                      if (openNode.PathLengthFromStart > neighbourNode.PathLengthFromStart)
                    {
                        // Шаг 9.
                        openNode.CameFrom = currentNode;
                        openNode.PathLengthFromStart = neighbourNode.PathLengthFromStart;
                    }
                }
            }
            // Шаг 10.
            return null;
        }
        private int GetHeuristicPathLength(Position from, Position to)
        {
            return Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);
        }
        private Collection<PathNode> GetNeighbours(PathNode pathNode,  Position goal, int[,] field)
        {
            var result = new Collection<PathNode>();

            // Соседними точками являются соседние по стороне клетки.
            Position[] neighbourPoints = new Position[4];
            neighbourPoints[0] = new Position(pathNode.position.X + 1, pathNode.position.Y);
            neighbourPoints[1] = new Position(pathNode.position.X - 1, pathNode.position.Y);
            neighbourPoints[2] = new Position(pathNode.position.X, pathNode.position.Y + 1);
            neighbourPoints[3] = new Position(pathNode.position.X, pathNode.position.Y - 1);

            foreach (var point in neighbourPoints)
            {
                // Проверяем, что не вышли за границы карты.
                if (point.X < 0 || point.X >= field.GetLength(0))
                    continue;
                if (point.Y < 0 || point.Y >= field.GetLength(1))
                    continue;
                // Проверяем, что по клетке можно ходить.
                if (field[point.X, point.Y] == Wall.GetNumberElement())
                    continue;
                // Заполняем данные для точки маршрута.
                var neighbourNode = new PathNode()
                {
                    position = point,
                    CameFrom = pathNode,
                    PathLengthFromStart = pathNode.PathLengthFromStart +
                    GetDistanceBetweenNeighbours(),
                    HeuristicEstimatePathLength = GetHeuristicPathLength(point, goal)
                };
                result.Add(neighbourNode);
            }
            return result;
        }
        private List<Position> GetPathForNode(PathNode pathNode)
        {
            var result = new List<Position>();
            var currentNode = pathNode;
            while (currentNode != null)
            {
                result.Add(currentNode.position);
                currentNode = currentNode.CameFrom;
            }
            result.Reverse();
            return result;
        }
        private int GetDistanceBetweenNeighbours()
        {
            return 1;
        }
    }
}
