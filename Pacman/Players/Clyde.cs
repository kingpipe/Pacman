using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PacMan.Abstracts;
using PacMan.Algorithms.Astar;
using PacMan.Foods;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Clyde : Ghost
    {
        private ICoord oldcoord;

        public Clyde(ICoord[,] map) : base(map)
        {
            StartPosition();
            oldcoord = new Empty(position);
        }
        public Clyde(Position position, ICoord[,] map) : base(map)
        {
            this.position = position;
            oldcoord = new Empty(position);
        }
        public override void StartPosition()
        {
            position = new Position(15, 11);
        }
        public async Task<bool> StartAsync(int time)
        {
            return await Task.Run(() =>
            {
                while (true)
                {
                    bool isEatPacman = Move();
                    if (isEatPacman == false)
                        return true;
                    Thread.Sleep(time);
                }
            });
        }
        public override bool Move()
        {
            PacmanPosition = SearchPacman(Map);

            if (PacmanPosition != position)
            {
                var astar = new AstarAlgorithm();
                Stack<Position> list = astar.FindPath(Map, position, PacmanPosition);
                oldcoord = Go(list, Map, oldcoord);
                if (PacmanPosition == position)
                {
                    oldcoord = new Empty(position);
                    return false;
                }
                return true;
            }
            else
            {
                oldcoord = new Empty(position);
                return false;
            }
        }

        private ICoord Go(Stack<Position> list, ICoord[,] map, ICoord coord)
        {
            map[position.X, position.Y] = coord;
            if (list.Count != 0)
                position = list.Pop();
            ICoord old = map[position.X, position.Y];
            map[position.X, position.Y] = new Clyde(position, Map);
            return old;
        }

        public static char GetCharElement()
        {
            return 'C';
        }
    }
}
