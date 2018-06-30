using System;
using System.Timers;
using PacMan.Abstracts;
using PacMan.Algorithms.Astar;
using PacMan.Foods;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Blinky : Ghost, IGetChar
    {
        public override event Action SinkAboutEatPacman;
        public override event Action<ICoord> Movement;

        public Blinky()
        { }

        public Blinky(Map map) : base(map)
        {
            strategy = new AstarAlgorithm();
        }

        public override void StartPosition()
        {
            Position = new Position(15, 11);
        }

        public override void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Movement(oldcoord);
            pacmanIsLive = Move();
            Movement(Map.GetElement(Position));
            if (pacmanIsLive == false)
            {
                SinkAboutEatPacman();
            }
        }

        public override bool Move()
        {
            lock (obj)
            {
                PacmanPosition = SearchPacman();

                if (PacmanPosition != Position)
                {
                    path = strategy.FindPath(Map, Position, PacmanPosition);
                    oldcoord = Go(path, oldcoord);
                    if (PacmanPosition == Position)
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override char GetCharElement()
        {
            return 'B';
        }
    }
}
