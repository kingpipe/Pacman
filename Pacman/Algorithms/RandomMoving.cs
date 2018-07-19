using System;
using System.Collections.Generic;
using PacMan.Interfaces;
using PacMan.Enums;

namespace PacMan.Algorithms
{
    class RandomMoving : IStrategy
    {
        private Stack<Position> shadow;
        private readonly Random random;
        private Direction direction;

        public RandomMoving()
        {
            shadow = new Stack<Position>();
            random = new Random();
            direction = (Direction)random.Next(1, 5);
        }

        public Stack<Position> FindPath(IMap map, Position start, Position goal)
        {
            switch (direction)
            {
                case Direction.Right:
                    GoStraight(new Position(start.X + 1, start.Y), map, ref shadow);
                    break;
                case Direction.Left:
                    GoStraight(new Position(start.X - 1, start.Y), map, ref shadow);
                    break;
                case Direction.Up:
                    GoStraight(new Position(start.X, start.Y - 1), map, ref shadow);
                    break;
                case Direction.Down:
                    GoStraight(new Position(start.X, start.Y + 1), map, ref shadow);
                    break;
            }
            if(shadow.Count==0)
            {
                direction = (Direction)random.Next(1, 5);
                shadow = FindPath(map, start, goal);
            }
            return shadow;
        }

        private void GoStraight(Position position, IMap map, ref Stack<Position> swadow)
        {
            if (CanMove(position, map))
            {
                swadow.Push(position);
            }
        }

        private bool CanMove(Position position, IMap map)
        {
            return map.OnMap(position) &&
                   !(map.map[position.X, position.Y] is Wall) &&
                   !(map.map[position.X, position.Y] is IGhost);
        }
    }
}
