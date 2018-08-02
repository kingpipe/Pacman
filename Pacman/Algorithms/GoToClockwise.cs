using System.Collections.Generic;
using PacMan.Enums;
using PacMan.Interfaces;

namespace PacMan.Algorithms
{
    class GoToClockwise : IStrategy
    {
        private Direction direction;

        public GoToClockwise()
        {
            direction = Direction.Right;
        }

        public Stack<Position> FindPath(IMap map, Position start, Position goal)
        {
            Stack<Position> path = new Stack<Position>();

            switch (direction)
            {
                case Direction.Down:
                    if (!(map[start.Left] is Wall))
                    {
                        path.Push(start.Left);
                        direction = Direction.Left;
                    }
                    else
                    {
                        if (!(map[start.Down] is Wall))
                        {
                            path.Push(start.Down);
                        }
                        else
                        {
                            path.Push(start.Right);
                            direction = Direction.Right;
                        }
                    }
                    break;
                case Direction.Left:
                    if (!(map[start.Up] is Wall))
                    {
                        path.Push(start.Up);
                        direction = Direction.Up;
                    }
                    else
                    {
                        if (!(map[start.Left] is Wall))
                        {
                            path.Push(start.Left);
                        }
                        else
                        {
                            path.Push(start.Down);
                            direction = Direction.Down;
                        }
                    }
                    break;
                case Direction.Up:
                    if (!(map[start.Right] is Wall))
                    {
                        path.Push(start.Right);
                        direction = Direction.Right;
                    }
                    else
                    {
                        if (!(map[start.Up] is Wall))
                        {
                            path.Push(start.Up);
                        }
                        else
                        {
                            path.Push(start.Left);
                            direction = Direction.Left;
                        }
                    }
                    break;
                case Direction.Right:
                    if (!(map[start.Down] is Wall))
                    {
                        path.Push(start.Down);
                        direction = Direction.Down;
                    }
                    else
                    {
                        if (!(map[start.Right] is Wall))
                        {
                            path.Push(start.Right);
                        }
                        else
                        {
                            path.Push(start.Up);
                            direction = Direction.Up;
                        }
                    }
                    break;
            }
            return path;
        }
    }
}
