using System;
using System.Collections.Generic;
using PacMan.Abstracts;
using PacMan.Algorithms.Astar;
using PacMan.Foods;
using PacMan.Interfaces;

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
                var astar = new AstarAlgorithm();
                List<Position> list= astar.FindPath(map, position, PacmanPosition);
                Go(list, map);
                if (PacmanPosition == position)
                    return false;
                return true;
            }
            else
                return false;
        }

        private void Go(List<Position> list, int [,] map)
        {
            map[position.X, position.Y] = Empty.GetNumberElement();
            position = list[1];
            list.Remove(position);
            map[position.X, position.Y] = GetNumberElement();
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
