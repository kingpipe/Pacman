using System.Collections.Generic;
using System.Timers;
using PacMan.Abstracts;
using PacMan.Algorithms.Astar;
using PacMan.Foods;

namespace PacMan.Players
{
    public class Clyde:Ghost
    {
        public Clyde():base()
        {
            StartPosition();
        }
        public override void StartPosition()
        {
            position = new Position(15, 11);
        }
        public bool Start(int [,] map, Timer timer)
        {
            while(true)
            {
                Move(map);
                timer.Start();
            }
        }
        public override bool Move(int [,] map)
        {
            PacmanPosition= SearchPacman(map);

            if (PacmanPosition != position)
            {
                var astar = new AstarAlgorithm();
                Stack<Position> list= astar.FindPath(map, position, PacmanPosition);
                Go(list, map);
                if (PacmanPosition == position)
                    return false;
                return true;
            }
            else
                return false;
        }

        private void Go(Stack<Position> list, int [,] map)
        {
            map[position.X, position.Y] = Empty.GetNumberElement();
            position = list.Pop();
            map[position.X, position.Y] = GetNumberElement();
        }

        public static char GetCharElement()
        {
            return 'C';
        }

        public static int GetNumberElement()
        {
            return 7;
        }
    }
}
