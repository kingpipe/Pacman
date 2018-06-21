using System;
using PacMan.Abstracts;
using PacMan.Foods;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Pacman : Player, IPacman
    {
        public int Lives { get; set; }

        public Pacman() : base()
        {
            Lives = 3;
            StartPosition();
        }
        public Pacman(Position position):base()
        {
            this.position = position;
        }
        public override void StartPosition()
        {
            position = new Position(15, 23);
        }

        public bool Move(Direction direction,ICoord [,] map)
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
        public override bool MoveRight(ICoord[,] map)
        {
            if (position.X + 3 > map.GetLength(1))
            {
                map[position.X, position.Y] =new Empty(position);
                position.X = 0;
                map[position.X, position.Y] = new Pacman(position);
                return true;
            }
            else
                return base.MoveRight(map);
        }

        public override bool MoveLeft(ICoord[,] map)
        {
            if (position.X - 1 < 0)
            {
                map[position.X, position.Y] = new Empty(position);
                position.X = map.GetLength(0)-1;
                map[position.X, position.Y] = new Pacman(position);
                return true;
            }
            else
            return base.MoveLeft(map);
        }
        public static char GetCharElement()
        {
            return 'P';
        }
    }
}
