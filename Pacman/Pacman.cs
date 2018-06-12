using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Pacman : Player
    {
        public Pacman() : base()
        {
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

    }
}
