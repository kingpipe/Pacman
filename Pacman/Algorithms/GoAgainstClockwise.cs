using System.Collections.Generic;
using PacMan.Enums;
using PacMan.Interfaces;

namespace PacMan.Algorithms
{
    class GoAgainstClockwise: IStrategy
    {
        private Direction _direction;

        public GoAgainstClockwise()
        {
            _direction = Direction.Left;
        }

        public Stack<Position> FindPath(IMap map, Position start, Position goal)
        {
            Stack<Position> path = new Stack<Position>();

            switch (_direction)
            {
                case Direction.Down:
                    if (!(map[start.Right] is Wall))
                    {
                        path.Push(start.Right);
                        _direction = Direction.Right;
                    }
                    else
                    {
                        if (!(map[start.Down] is Wall))
                        {
                            path.Push(start.Down);
                        }
                        else
                        {
                            path.Push(start.Left);
                            _direction = Direction.Left;
                        }
                    }
                    break;
                case Direction.Left:
                    if (!(map[start.Down] is Wall))
                    {
                        path.Push(start.Down);
                        _direction = Direction.Down;
                    }
                    else
                    {
                        if (!(map[start.Left] is Wall))
                        {
                            path.Push(start.Left);
                        }
                        else
                        {
                            path.Push(start.Up);
                            _direction = Direction.Up;
                        }
                    }
                    break;
                case Direction.Up:
                    if (!(map[start.Left] is Wall))
                    {
                        path.Push(start.Left);
                        _direction = Direction.Left;
                    }
                    else
                    {
                        if (!(map[start.Up] is Wall))
                        {
                            path.Push(start.Up);
                        }
                        else
                        {
                            path.Push(start.Right);
                            _direction = Direction.Right;
                        }
                    }
                    break;
                case Direction.Right:
                    if (!(map[start.Up] is Wall))
                    {
                        path.Push(start.Up);
                        _direction = Direction.Up;
                    }
                    else
                    {
                        if (!(map[start.Right] is Wall))
                        {
                            path.Push(start.Right);
                        }
                        else
                        {
                            path.Push(start.Down);
                            _direction = Direction.Down;
                        }
                    }
                    break;
            }
            return path;
        }
    }
}
