using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using PacMan.Abstracts;
using PacMan.Algorithms.Astar;
using PacMan.Foods;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Clyde : Ghost
    {
        public event Action SinkAboutEatPacman;
        private ICoord oldcoord;

        public Clyde(Map map) : base(map)
        {
            StartPosition();
            oldcoord = new Empty(Position);
        }

        public override void StartPosition()
        {
            Position = new Position(15, 11);
        }
        public async Task StartAsync(int time)
        {
            await Task.Run(() =>
            {
                bool pacmanIsLive = true;
                while (pacmanIsLive)
                {
                    pacmanIsLive = Move();
                    if (pacmanIsLive == false && SinkAboutEatPacman != null)
                    {
                        SinkAboutEatPacman();
                    }
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
            Map.SetElement(new Clyde(Map));
            return old;
        }

        public static char GetCharElement()
        {
            return 'C';
        }
    }
}
