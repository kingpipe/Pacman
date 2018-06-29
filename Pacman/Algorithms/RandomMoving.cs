using System;
using System.Collections.Generic;
using PacMan.Interfaces;

namespace PacMan.Algorithms
{
    class RandomMoving : IStrategy
    {
        public Stack<Position> FindPath(IMap map, Position start, Position goal)
        {
            Stack<Position> Shadow = new Stack<Position>();
            Random random = new Random();
            while (Shadow.Count == 0)
            {
                Direction direction = (Direction)random.Next(1, 5);

                switch (direction)
                {
                    case Direction.Right:
                        GoStraightRight(new Position(start.X + 1, start.Y), map, ref Shadow);
                        break;
                    case Direction.Left:
                        GoStraightLeft(new Position(start.X - 1, start.Y), map, ref Shadow);
                        break;
                    case Direction.Up:
                        GoStraightUp(new Position(start.X, start.Y - 1), map, ref Shadow);
                        break;
                    case Direction.Down:
                        GoStraightDown(new Position(start.X, start.Y + 1), map, ref Shadow);
                        break;
                }
            }
            return Shadow;
        }

        private void GoStraightLeft(Position position, IMap map, ref Stack<Position> swadow)
        {
            if (CanMove(position, map))
            {
                GoStraightLeft(new Position(position.X - 1, position.Y), map, ref swadow);
                swadow.Push(position);
            }
        }

        private void GoStraightRight(Position position, IMap map, ref Stack<Position> swadow)
        {
            if (CanMove(position, map))
            {
                GoStraightRight(new Position(position.X + 1, position.Y), map, ref swadow);
                swadow.Push(position);
            }
        }

        private void GoStraightUp(Position position, IMap map, ref Stack<Position> swadow)
        {
            if (CanMove(position, map))
            {
                GoStraightUp(new Position(position.X, position.Y - 1), map, ref swadow);
                swadow.Push(position);
            }
        }

        private void GoStraightDown(Position position, IMap map, ref Stack<Position> swadow)
        {
            if (CanMove(position, map))
            {
                GoStraightDown(new Position(position.X, position.Y + 1), map, ref swadow);
                swadow.Push(position);
            }
        }

        private bool CanMove(Position position, IMap map)
        {
            return !(map.map[position.X, position.Y] is Wall) &&
                   !(map.map[position.X, position.Y] is IGhost) &&
                   map.OnBoard(position);
        }
    }
}
