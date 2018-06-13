using System;
using System.Timers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Clyde:IGhost
    {
        public Clyde():base()
        {
            position = new Position(20, 12);
        }

        public void Start(Timer timer, int[,] map)
        {
            timer.Elapsed += Step;
        }
        private static void Step(Object source, ElapsedEventArgs e)
        {
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
