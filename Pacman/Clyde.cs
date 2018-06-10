using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Clyde:Player
    {
        public Clyde(Position position):base(position)
        {

        }

        private Position PacmanPosition;
        private Position SearchPacman(Game game)
        {
            int[,] map = game.map;
            for (int y = 0; y < 16; y++)
                for (int x = 0; x < 32; x++)
                    if (map[x, y] == (int)Elements.Pacman)
                        return new Position(x, y);
            return position;
        }
        public bool Move(Game game)
        {
            PacmanPosition= SearchPacman(game);

            if (PacmanPosition != position)
            {
                GoToPacman(game);
                return true;
            }
            else
                return false;
        }

        private void GoToPacman(Game game)
        {
            int DeltaX = position.X - PacmanPosition.X;
            int DeltaY = position.Y - PacmanPosition.Y;
            if (Math.Abs(DeltaX) > Math.Abs(DeltaY))
            {
                if (DeltaX > 0)
                    MoveLeft(game, Elements.Clyde);
                else
                    MoveRight(game, Elements.Clyde);
            }
            else
            {
                if (DeltaY > 0)
                    MoveUp(game, Elements.Clyde);
                else
                    MoveDown(game, Elements.Clyde);
            }
        }
    }
}
