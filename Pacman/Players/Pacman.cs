using System;
using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Pacman : Player, IPacman
    {
        public int Lives { get; set; }

        public Pacman() : base()
        {
            Lives = 3;
            position = new Position(7, 6);
        }

        public bool Move(Direction direction,int [,] map)
        {
            switch (direction)
            {
                case Direction.Left:
                    return MoveLeft(map);
                case Direction.Right:
                    return MoveRight(map);
                case Direction.Up:
                    return MoveUp(map);
                case Direction.Down:
                    return MoveDown(map);
                default:
                    return false;
            }
        }

        public static int GetNumberElement()
        {
            return 5;
        }

        public static char GetCharElement()
        {
            return 'P';
        }
    }
}
