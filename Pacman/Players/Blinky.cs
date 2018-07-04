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
        private int countMove;
        public Blinky()
        { }

        public Blinky(Map map) : base(map)
        {
            Strategy = new RandomMoving();
            countMove = 0;
        }

        public override void StartPosition()
        {
            Position = new Position(15, 11);
        }

        public override void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Movement(OldCoord);
            pacmanIsLive = Move();
            Movement(Map.GetElement(Position));
            if (!pacmanIsLive)
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
                    path = Strategy.FindPath(Map, Position, PacmanPosition);
                    OldCoord = Go(path, OldCoord);
                    countMove++;
                    if (PacmanPosition != Position)
                    {
                        return true;
                    }
                    return GhostIsFrightened();
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
