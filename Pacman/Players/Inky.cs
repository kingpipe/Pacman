using PacMan.Abstracts;
using PacMan.Algorithms;
using PacMan.Foods;
using PacMan.Interfaces;
using System;
using System.Timers;

namespace PacMan.Players
{
    public class Inky : Ghost, IGetChar
    {
        public override event Action SinkAboutEatPacman;
        public override event Action<ICoord> Movement;

        public Inky()
        { }

        public Inky(Map map) : base(map)
        {
            strategy = new GoAway();
        }

        public override void StartPosition()
        {
            Position = new Position(10, 11);
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
            return 'I';
        }

    }
}
