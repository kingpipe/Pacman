using System.Collections.Generic;
using PacMan.Abstracts;
using PacMan.Algorithms.Astar;
using PacMan.Foods;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Clyde : Ghost
    {
        private ICoord oldcoord;

        public Clyde() : base()
        {
            StartPosition();
            oldcoord = new Empty(position);
        }
        public Clyde(Position position) : base()
        {
            this.position = position;
            oldcoord = new Empty(position);
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
                oldcoord=Go(list, map, oldcoord);
                if (PacmanPosition == position)

                    return false;
                return true;
            }
            else
                return false;
        }

        private ICoord Go(Stack<Position> list, ICoord[,] map, ICoord coord)
        {
            map[position.X, position.Y] = coord;
            if (list.Count != 0)
                position = list.Pop();
            ICoord old=map[position.X, position.Y];
            map[position.X, position.Y] = new Clyde(position);
            return old;
        }

        public static char GetCharElement()
        {
            return 'C';
        }
    }
}
