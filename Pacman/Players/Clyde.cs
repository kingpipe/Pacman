using System;
using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Clyde:Ghost
    {
        public Clyde():base()
        {
            position = new Position(20, 12);
        }

        public static char GetCharElement()
        {
            return 'C';
        }

        public static int GetNumberElement()
        {
            return 7;
        }

        public override bool Move(int [,] map)
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
