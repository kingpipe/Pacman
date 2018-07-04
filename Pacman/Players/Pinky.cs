using PacMan.Abstracts;
using PacMan.Algorithms;
using PacMan.Interfaces;
using System;
using System.Timers;

namespace PacMan.Players
{
    public class Pinky : Ghost, IGetChar
    {
        public override event Action SinkAboutEatPacman;
        public override event Action<ICoord> Movement;

        public Pinky()
        { }

        public Pinky(Map map, int time) :base(map, time)
        {
            Strategy = new RandomMoving();
        }


        public override void StartPosition()
        {
            Position = new Position(17, 15);
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
            return 'N';
        }

    }
}
