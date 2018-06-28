using System;
using System.Timers;
using PacMan.Abstracts;
using PacMan.Algorithms;
using PacMan.Foods;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Clyde : Ghost
    {
        public override event Action SinkAboutEatPacman;
        public override event Action<ICoord> Moving;
        public override event Action<ICoord> Moved;

        public Clyde(Map map) : base(map)
        {
            StartPosition();
            strategy = new RandomMoving();
        }

        public override void StartPosition()
        {
            Position = new Position(19, 11);
        }
        
        protected override void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Moving(Map.GetElement(Position));
            pacmanIsLive = Move();
            Moved(Map.GetElement(Position));
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
                    if (list.Count == 0)
                    {
                        list = strategy.FindPath(Map, Position, PacmanPosition);
                    }
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
        }

        public static char GetCharElement()
        {
            return 'C';
        }
    }
}
