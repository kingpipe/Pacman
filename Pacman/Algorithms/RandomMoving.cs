using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PacMan.Algorithms.Astar;
using PacMan.Interfaces;

namespace PacMan.Algorithms
{
    class RandomMoving : IStrategy
    {
        public Stack<Position> FindPath(ICoord[,] map, Position start, Position goal)
        {
            Stack<Position> Shadow = new Stack<Position>();
            return GetWay(map, start, Shadow);
        }

        private Stack<Position> GetWay(ICoord[,] map, Position start, Stack<Position> Shadow)
        {
            Random random = new Random();
            Direction direction = (Direction)random.Next(1, 4);

            if (direction == Direction.Right)
                GoStraightRight(new Position(start.X + 1, start.Y), map, ref Shadow);
            if (direction == Direction.Left)
                GoStraightLeft(new Position(start.X - 1, start.Y), map, ref Shadow);
            if (direction == Direction.Down)
                GoStraightDown(new Position(start.X, start.Y + 1), map, ref Shadow);
            if (direction == Direction.Up)
                GoStraightUp(new Position(start.X, start.Y - 1), map, ref Shadow);
            return Shadow;
        }

        private void GoStraightLeft(Position position, ICoord[,] map, ref Stack<Position> swadow)
        {
            if (!(map[position.X, position.Y] is Wall))
            {
                GoStraightLeft(new Position(position.X - 1, position.Y), map, ref swadow);
                swadow.Push(position);
            }
        }

        private void GoStraightRight(Position position, ICoord[,] map, ref Stack<Position> swadow)
        {
            if (!(map[position.X, position.Y] is Wall))
            {
                GoStraightRight(new Position(position.X + 1, position.Y), map, ref swadow);
                swadow.Push(position);
            }
        }

        private void GoStraightUp(Position position, ICoord[,] map, ref Stack<Position> swadow)
        {
            if (!(map[position.X, position.Y] is Wall))
            {
                GoStraightUp(new Position(position.X, position.Y - 1), map, ref swadow);
                swadow.Push(position);
            }
        }

        private void GoStraightDown(Position position, ICoord[,] map, ref Stack<Position> swadow)
        {
            if (!(map[position.X, position.Y] is Wall))
            {
                GoStraightDown(new Position(position.X, position.Y + 1), map, ref swadow);
                swadow.Push(position);
            }
        }

    }
}
