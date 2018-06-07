using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Pacman:Player
    {
        public Pacman(Position position):base(position)
        {

        }

        public void MoveLeft(Game game)
        {
            if (position.X != (int)Elements.Wall)
            {
                game.map[position.X, position.Y] = (int)Elements.None;
                game.map[position.X - 1, position.Y] = (int)Elements.Pacman;
                position.X = position.X - 1;
            }
        }
    }
}
