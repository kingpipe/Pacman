using System;
using System.Timers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Clyde:Ghost
    {
        public Clyde():base()
        {
            position = new Position(20, 12);
        }

        private Position PacmanPosition;
        private Position SearchPacman(int [,] map)
        {
            for (int y = 0; y < 16; y++)
                for (int x = 0; x < 32; x++)
                    if (map[x, y] == (int)Elements.Pacman)
                        return new Position(x, y);
            return position;
        }
        public bool Move(int [,] map)
        {
            PacmanPosition= SearchPacman(map);

            if (PacmanPosition != position)
            {
                GoToPacman(map);
                if (PacmanPosition == position)
                    return false;
                return true;
            }
            else
                return false;
        }

        private void GoToPacman(int [,] map)
        {
            int DeltaX = position.X - PacmanPosition.X;
            int DeltaY = position.Y - PacmanPosition.Y;
            if (Math.Abs(DeltaX) > Math.Abs(DeltaY))
            {
                if (DeltaX > 0)
                    MoveLeft(map);
                else
                    MoveRight(map);
            }
            else
            {
                if (DeltaY > 0)
                    MoveUp(map);
                else
                    MoveDown(map);
            }
        }
    }
}
