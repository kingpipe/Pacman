using System;
using System.Collections.Generic;

namespace Pacman
{
    class Blinky: IGhost
    {
        public Blinky():base()
        {
        }
        
        public bool Move(int [,] map)
        {
            PacmanPosition = SearchPacman(map);
            Queue<Position> shortpath =Algorithm.Dijkstra(map, position, PacmanPosition);

            Step(shortpath, map);
            return true;
        }

        private void Step(Queue<Position> shortpath, int[,] map)
        {
            Position NextDot = shortpath.Dequeue();
            map[position.X, position.Y] = (int)Elements.None;
            map[NextDot.X, NextDot.Y] = (int)Elements.Blinky;
        }

    }
}
