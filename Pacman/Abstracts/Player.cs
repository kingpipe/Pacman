using System;
using System.Timers;
using PacMan.ExtensionClasses;
using PacMan.Interfaces;

namespace PacMan.Abstracts
{
    abstract class Player : IMovable, ISinkMoving, ITimer
    {
        public abstract event Action<ICoord> Movement;
        public abstract void StartPosition();
        public abstract string GetId();
        public abstract char GetCharElement();
        public abstract bool Move();
        public abstract void TimerElapsed(object sender, ElapsedEventArgs e);

        public Map Map { get; set; }
        public Position Position { get; set; }
        public Direction Direction { get; set; }
        public Timer Timer { get; set; }
        public int Time { get; set; }

        protected Player()
        { }

        protected Player(Map map, int time)
        {
            Time = time;
            Map = map;
        }

        public virtual void Start()
        {
            Timer.Start(TimerElapsed);
        }

        public virtual void Stop()
        {
            Timer.Stop(TimerElapsed);
        }

        public virtual bool MoveLeft()
        {
            if (!(Map.GetElementLeft(Position) is Wall))
            {
                SwapPlacesX(Position.X - 1);
                return true;
            }
            return false;
        }

        public virtual bool MoveRight()
        {
            if (!(Map.GetElementRight(Position) is Wall))
            {
                SwapPlacesX(Position.X + 1);
                return true;
            }
            return false;
        }

        public virtual bool MoveUp()
        {
            if (!(Map.GetElementUp(Position) is Wall))
            {
                SwapPlacesY(Position.Y - 1);
                return true;
            }
            return false;
        }

        public virtual bool MoveDown()
        {
            if (!(Map.GetElementDown(Position) is Wall))
            {
                SwapPlacesY(Position.Y + 1);
                return true;
            }
            return false;
        }

        private void SwapPlacesX(int x)
        {
            var value = Map.GetElement(Position);
            Map.SetElement(new Empty(Position));
            Position position = Position;
            position.X = x;
            Position = position;
            Map.SetElement(value, Position);
        }

        private void SwapPlacesY(int y)
        {
            var value = Map.GetElement(Position);
            Map.SetElement(new Empty(Position));
            Position position = Position;
            position.Y = y;
            Position = position;
            Map.SetElement(value, Position);
        }
    }
}