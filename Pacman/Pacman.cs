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
            if (game.map[position.X - 1, position.Y] != (int)Elements.Wall)
            {
                game.map[position.X, position.Y] = (int)Elements.None;
                game.map[position.X - 1, position.Y] = (int)Elements.Pacman;
                position.X = position.X - 1;
            }
        }

        public void MoveRight(Game game)
        {
            if (game.map[position.X+1, position.Y]!= (int)Elements.Wall)
            {
                game.map[position.X, position.Y] = (int)Elements.None;
                game.map[position.X + 1, position.Y] = (int)Elements.Pacman;
                position.X = position.X + 1;
            }
        }

        public void MoveUp(Game game)
        {
            if (game.map[position.X, position.Y-1] != (int)Elements.Wall)
            {
                game.map[position.X, position.Y] = (int)Elements.None;
                game.map[position.X, position.Y-1] = (int)Elements.Pacman;
                position.Y = position.Y - 1;
            }
        }

        public void MoveDown(Game game)
        {
            if (game.map[position.X, position.Y + 1] != (int)Elements.Wall)
            {
                game.map[position.X, position.Y] = (int)Elements.None;
                game.map[position.X, position.Y+1] = (int)Elements.Pacman;
                position.Y = position.Y+1;
            }
        }
    }
}
