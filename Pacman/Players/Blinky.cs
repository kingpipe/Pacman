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
    public class Blinky : Ghost
    {
        public object obj = new object();
        public override event Action SinkAboutEatPacman;

        public Blinky(Map map) : base(map)
        {
            StartPosition();
            oldcoord = new Empty(Position);
        }

        public override void StartPosition()
        {
            Position = new Position(15, 11);
        }

        public void Start(System.Timers.Timer blinkyTimer)
        {
            blinkyTimer.Elapsed += BlinkyTimer_Elapsed;
            blinkyTimer.Start();
        }
        public void Stop(System.Timers.Timer blinkyTimer)
        {
            blinkyTimer.Elapsed -= BlinkyTimer_Elapsed;
            blinkyTimer.Stop();
        }

        private void BlinkyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            PacmanIsLive = Move();
            if (PacmanIsLive == false)
            {
                //((System.Timers.Timer)sender).Stop();
                SinkAboutEatPacman();
            }
        }



        public virtual async Task StartAsync(int time)
        {
            await Task.Run(() =>
            {
                lock (obj)
                {
                    while (true)
                    {
                        PacmanIsLive = Move();
                        if (PacmanIsLive == false && SinkAboutEatPacman != null)
                        {
                            SinkAboutEatPacman();
                            break;
                        }
                        Thread.Sleep(time);
                    }
                }
            });
        }

        public override bool Move()
        {
            lock (obj)
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
        }

        private ICoord Go(Stack<Position> list, ICoord coord)
        {
            Map.SetElement(coord, Position);
            if (list.Count != 0)
                Position = list.Pop();
            ICoord old = Map.GetElement(Position);
            Map.SetElement(this, Position);
            return old;
        }

        public static char GetCharElement()
        {
            return 'B';
        }
    }
}
