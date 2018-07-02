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

        public Pinky(Map map):base(map)
        {
            strategy = new RandomMoving();
        }


        public override void StartPosition()
        {
            Position = new Position(17, 15);
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
