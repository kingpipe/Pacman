using System.Collections.Generic;
using System.Timers;
using PacMan.Abstracts;
using PacMan.Algorithms.Astar;
using PacMan.Foods;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Clyde : Ghost
    {
        public Clyde() : base()
        {
            StartPosition();
        }
        public Clyde(Position position) : base()
        {
            this.position = position;
        }
        public override void StartPosition()
        {
            position = new Position(15, 11);
        }

        public override bool Move(ICoord[,] map)
        {
            PacmanPosition = SearchPacman(map);

            if (PacmanPosition != position)
            {
                var astar = new AstarAlgorithm();
                Stack<Position> list = astar.FindPath(map, position, PacmanPosition);
                Go(list, map);
                if (PacmanPosition == position)
                    return false;
                return true;
            }
            else
                return false;
        }

        private void Go(Stack<Position> list, ICoord[,] map)
        {
            map[position.X, position.Y] = new Empty(position);
            if (list.Count != 0)
                position = list.Pop();
            map[position.X, position.Y] = new Clyde(position);
        }

        public static char GetCharElement()
        {
            return 'C';
        }
    }
}
