﻿using System;
using System.Timers;
using PacMan.ExtensionClasses;
using PacMan.Interfaces;
using PacMan.Enums;

namespace PacMan.Abstracts
{
    abstract class Player : IMovable, ISinkMoving
    {
        public abstract event Action<ICoord> Movement;
        public abstract bool Move();
        public abstract void RemoveFromMap();
        public abstract void SetOnMap();
        protected abstract void TimerElapsed(object sender, ElapsedEventArgs e);

        protected Position start;
        protected string id;
        protected char idchar;

        public Map Map { get; set; }
        public Position Position { get; set; }
        public Direction Direction { get; set; }
        public Timer Timer { get; set; }
        public int Time { get; set; }
        public virtual Position StartCoord
        {
            get => start;
            set
            {
                start = value;
                StartPosition();
            }
        }
        
        protected Player(Map map, Position start)
        {
            Map = map;
            StartCoord = start;
        }

        public virtual string GetId() => id;
        public char GetCharElement() => idchar;
        public virtual void StartPosition() => Position = StartCoord;

        public virtual void Start() => Timer.Start(TimerElapsed);
        public virtual void Stop() => Timer.Stop(TimerElapsed);
        
        public virtual void Default(Map map)
        {
            Stop();
            Map = map;
            StartPosition();
        }

        public void SetTime(int time)
        {
            Timer.Interval = time;
            Time = time;
        }

        protected virtual bool MoveLeft()
        {
            if (!(Map[Position.Left] is Wall))
            {
                SwapPlacesX(Position.X - 1);
                return true;
            }
            return false;
        }

        protected virtual bool MoveRight()
        {
            if (!(Map[Position.Right] is Wall))
            {
                SwapPlacesX(Position.X + 1);
                return true;
            }
            return false;
        }

        protected virtual bool MoveUp()
        {
            if (!(Map[Position.Up] is Wall))
            {
                SwapPlacesY(Position.Y - 1);
                return true;
            }
            return false;
        }

        protected virtual bool MoveDown()
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