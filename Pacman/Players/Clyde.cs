using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PacMan.Abstracts;
using PacMan.Algorithms;
using PacMan.Foods;
using PacMan.Interfaces;

namespace PacMan.Players
{
    public class Clyde : Ghost
    {
        private object obj = new object();
        public override event Action SinkAboutEatPacman;
        private Stack<Position> list = new Stack<Position>();
        private IStrategy random = new RandomMoving();
        public Clyde(Map map) : base(map)
        {
            StartPosition();
            oldcoord = new Empty(Position);
        }

        public override void StartPosition()
        {
            Position = new Position(19, 11);
        }
        public void Start(System.Timers.Timer clydeTimer)
        {
            clydeTimer.Elapsed += ClydeTimer_Elapsed;
            clydeTimer.Start();
        }

        public void Stop(System.Timers.Timer clydeTimer)
        {
            clydeTimer.Elapsed -= ClydeTimer_Elapsed;
            clydeTimer.Stop();
        }

        private void ClydeTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            PacmanIsLive = Move();
            if (PacmanIsLive == false)
            {
                //((System.Timers.Timer)sender).Stop();
                SinkAboutEatPacman();
            }
        }

        public async Task StartAsync(int time)
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
                    if (list.Count == 0)
                    {
                        list = random.FindPath(Map.map, Position, PacmanPosition);
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
            return 'C';
        }
    }
}
