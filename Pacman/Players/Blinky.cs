using System;
using System.Timers;
using PacMan.Abstracts;
using PacMan.Algorithms;
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
            strategy = new RandomMoving();
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
                    if (PacmanPosition != Position)
                    {
                        return true;
                    }
                    else
                    {
                        return GhostIsFrightened();
                    }
                }
                else
                {
                    return GhostIsFrightened();
                }
            }
        }
        
        public override char GetCharElement()
        {
            return 'B';
        }
    }
}
