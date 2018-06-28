using PacMan.Foods;
using PacMan.Interfaces;
using PacMan.Players;
using System;
using System.Collections.Generic;
using System.Timers;

namespace PacMan.Abstracts
{
    abstract public class Ghost : Player, IGhost, IFood, IEventSink
    {
        public abstract event Action SinkAboutEatPacman;
        public abstract event Action<ICoord> Moving;
        public abstract event Action<ICoord> Moved;
        protected abstract void TimerElapsed(object sender, ElapsedEventArgs e);
        public abstract bool Move();

        protected object obj = new object();
        protected bool pacmanIsLive = true;
        protected ICoord oldcoord;
        protected Stack<Position> list;
        protected IStrategy strategy;

        protected Position PacmanPosition { get; set; }
        public bool Frightened { get; set; }
        public int Score { get; set; }
        public bool IsLive { get; set; }

        public Ghost(Map map) : base(map)
        {
            PacmanPosition = SearchPacman();
            list = new Stack<Position>();
            oldcoord = new Empty(Position);

            Score = 200;
            IsLive = true;
            Frightened = false;
        }
        public Ghost()
        {
        }

        protected Position SearchPacman()
        {
            for (int y = 0; y < Map.Height; y++)
                for (int x = 0; x < Map.Width; x++)
                    if (Map.map[x, y] is Pacman)
                        return new Position(x, y);
            return PacmanPosition;
        }

        public void Start(Timer timer)
        {
            timer.Elapsed += TimerElapsed;
            timer.Start();
        }
        
        public void Stop(Timer timer)
        {
            timer.Elapsed -= TimerElapsed;
            timer.Stop();
        }

        protected virtual ICoord Go(Stack<Position> list, ICoord coord)
        {
            Map.SetElement(coord, Position);
            if (list.Count != 0)
                Position = list.Pop();
            ICoord old = Map.GetElement(Position);
            Map.SetElement(this, Position);
            return old;
        }
        public override char GetCharElement()
        {
            return ' ';
        }
    }
}
