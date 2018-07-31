using System;
using System.Timers;
using PacMan.ExtensionClasses;
using PacMan.Interfaces;
using PacMan.Enums;

namespace PacMan.Abstracts
{
    abstract class Player : IMovable, ISinkMoving, ITimer
    {
        public abstract event Action<ICoord> Movement;
        public abstract string GetId();
        public abstract char GetCharElement();
        public abstract bool Move();
        public abstract void RemoveFromMap();
        public abstract void SetOnMap();
        public abstract void TimerElapsed(object sender, ElapsedEventArgs e);
        protected Position start;

        public Map Map { get; set; }
        public Position Position { get; set; }
        public virtual Position StartCoord
        {
            get => start;
            set
            {
                start = value;
                StartPosition();
            }
        }
        public Direction Direction { get; set; }
        public Timer Timer { get; set; }
        public int Time { get; set; }

        protected Player(Map map, Position start)
        {
            Map = map;
            StartCoord = start;
        }

        public void SetTime(int time)
        {
            Timer.Interval = time;
            Time = time;
        }

        public void StartPosition()
        {
            Position = StartCoord;
        }

        public virtual void Start()
        {
            Timer.Start(TimerElapsed);
        }

        public virtual void Stop()
        {
            Timer.Stop(TimerElapsed);
        }

        public virtual void Default(Map map)
        {
            Stop();
            Map = map;
            StartPosition();
        }

        public virtual bool MoveLeft()
        {
            if (!(Map[Position.Left] is Wall))
            {
                SwapPlacesX(Position.X - 1);
                return true;
            }
            return false;
        }

        public virtual bool MoveRight()
        {
            if (!(Map[Position.Right] is Wall))
            {
                SwapPlacesX(Position.X + 1);
                return true;
            }
            return false;
        }

        public virtual bool MoveUp()
        {
            if (!(Map[Position.Up] is Wall))
            {
                SwapPlacesY(Position.Y - 1);
                return true;
            }
            return false;
        }

        public virtual bool MoveDown()
        {
            if (!(Map[Position.Down] is Wall))
            {
                SwapPlacesY(Position.Y + 1);
                return true;
            }
            return false;
        }

        private void SwapPlacesX(int x)
        {
            var value = Map[Position];
            Map[Position] = new Empty(Position);

            Position position = Position;
            position.X = x;
            Position = position;

            value.Position = Position;
            Map[value.Position] = value;
        }

        private void SwapPlacesY(int y)
        {
            var value = Map[Position];
            Map[Position] = new Empty(Position);

            Position position = Position;
            position.Y = y;
            Position = position;

            value.Position = Position;
            Map[value.Position] = value;
        }
    }
}