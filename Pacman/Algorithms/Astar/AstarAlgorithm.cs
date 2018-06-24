using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PacMan.Algorithms.Astar
{
    class AstarAlgorithm : IStrategy
    {
        public Stack<Position> FindPath(ICoord[,] map, Position start, Position goal)
        {
            var closedSet = new Collection<PathNode>();
            var openSet = new Collection<PathNode>();

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
                var currentNode = openSet.OrderBy(node =>
                  node.EstimateFullPathLength).First();
                if (currentNode.position == goal)
                    return GetPathForNode(currentNode);
                openSet.Remove(currentNode);
                closedSet.Add(currentNode);
                foreach (var neighbourNode in GetNeighbours(currentNode, goal, map))
                {
                    if (closedSet.Count(node => node.position == neighbourNode.position) > 0)
                        continue;
                    var openNode = openSet.FirstOrDefault(node =>
                      node.position == neighbourNode.position);
                    if (openNode == null)
                        openSet.Add(neighbourNode);
                    else
                    if (openNode.PathLengthFromStart > neighbourNode.PathLengthFromStart)
                    {
                        openNode.CameFrom = currentNode;
                        openNode.PathLengthFromStart = neighbourNode.PathLengthFromStart;
                    }
                }
            }
            return null;
        }
        private int GetHeuristicPathLength(Position from, Position to)
        {
            return Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);
        }
        private Collection<PathNode> GetNeighbours(PathNode pathNode, Position goal, ICoord[,] field)
        {
            var result = new Collection<PathNode>();

            Position[] neighbourPoints = new Position[4];
            neighbourPoints[0] = new Position(pathNode.position.X + 1, pathNode.position.Y);
            neighbourPoints[1] = new Position(pathNode.position.X - 1, pathNode.position.Y);
            neighbourPoints[2] = new Position(pathNode.position.X, pathNode.position.Y + 1);
            neighbourPoints[3] = new Position(pathNode.position.X, pathNode.position.Y - 1);

            foreach (var point in neighbourPoints)
            {
                if (point.X < 0 || point.X >= field.GetLength(0))
                    continue;
                if (point.Y < 0 || point.Y >= field.GetLength(1))
                    continue;
                if (field[point.X, point.Y] is Wall || field[point.X, point.Y] is IGhost)
                    continue;
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
        private Stack<Position> GetPathForNode(PathNode pathNode)
        {
            var result = new Stack<Position>();
            var currentNode = pathNode;
            while (currentNode != null)
            {
                result.Push(currentNode.position);
                currentNode = currentNode.CameFrom;
            }
            result.Pop();
            return result;
        }
        private int GetDistanceBetweenNeighbours()
        {
            return 1;
        }
    }
}
