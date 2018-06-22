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

        public Clyde(Map map) : base(map)
        {
            StartPosition();
            oldcoord = new Empty(Position);
        }
        public Clyde(Position position, Map map) : base(map)
        {
            this.Position = position;
            oldcoord = new Empty(position);
        }
        public override void StartPosition()
        {
            Position = new Position(15, 11);
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
            PacmanPosition = SearchPacman();

            if (PacmanPosition != Position)
            {
                var astar = new AstarAlgorithm();
                Stack<Position> list = astar.FindPath(Map.map, Position, PacmanPosition);
                oldcoord = Go(list, oldcoord);
                if (PacmanPosition == Position)
                {
                    oldcoord = new Empty(Position);
                    return false;
                }
                return true;
            }
            else
            {
                oldcoord = new Empty(Position);
                return false;
            }
        }

        private ICoord Go(Stack<Position> list, ICoord coord)
        {
            Map.SetElement(coord);
            if (list.Count != 0)
                Position = list.Pop();
            ICoord old = Map.GetElement(Position);
            Map.SetElement(new Clyde(Position, Map));
            return old;
        }

        public static char GetCharElement()
        {
            return 'C';
        }
    }
}
