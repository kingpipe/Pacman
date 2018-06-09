using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Pacman : Player
    {
        public Pacman(Position position) : base(position)
        {

        }
        public bool Move(Direction direction, Game game)
        {
            this.direction = direction;
            switch (this.direction)
            {
                case Direction.Left:
                    return MoveLeft(game,Elements.Pacman);
                case Direction.Right:
                    return MoveRight(game, Elements.Pacman);
                case Direction.Up:
                    return MoveUp(game, Elements.Pacman);
                case Direction.Down:
                    return MoveDown(game, Elements.Pacman);
                default:
                    return false;
            }
        }

    }
}
