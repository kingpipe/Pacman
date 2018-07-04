﻿using PacMan.Abstracts;
using PacMan.Foods;
using PacMan.Interfaces;
using System;
using System.Timers;

namespace PacMan.Players
{
    public class Pacman : Player, IPacman, ISinkMoving
    {
        public override event Action<ICoord> Movement;
        public event Action SinkAboutCreateCherry;
        public event Action SinkAboutEatEnergizer;
        public event Action SinkAboutNextLevel;
        public Direction direction { get; set; }
        public int Lives { get; set; }
        public int Count { get; set; }
        public int Level { get; set; }

        public Pacman()
        { }

        public Pacman(Map map) : base(map)
        {
            StartPosition();
            direction = Direction.None;
            Count = 0;
            Lives = 3;
            Level = 1;
        }

        public override void StartPosition()
        {
            Position = new Position(15, 23);
        }

        public override void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Movement(new Empty(Position));
            Move();
            Movement(Map.GetElement(Position));
        }

        public void Eat(IFood food)
        {
            if (food is IGhost)
            {
                if (((IGhost)food).Frightened)
                {
                    var ghost = (Ghost)food;
                    ghost.OldCoord = this;
                    ghost.StartPosition();
                    ghost.Frightened = false;
                }
            }
            else
            {
                if (food is Energizer)
                {
                    SinkAboutEatEnergizer();
                }
                if (food is LittleGoal)
                {
                    Map.CountLittleGoal--;
                }
            }
            Count += food.Score;
            food.IsLive = false;

            if (Count % 1000 == 700)
            {
                SinkAboutCreateCherry();
            }
            if (Map.CountLittleGoal == 0)
            {
                Level++;
                SinkAboutNextLevel();
            }

        }
        public override bool Move()
        {
            switch (direction)
            {
                case Direction.Left:
                    return MoveLeft();
                case Direction.Right:
                    return MoveRight();
                case Direction.Up:
                    return MoveUp();
                case Direction.Down:
                    return MoveDown();
                default:
                    direction = Direction.None;
                    return false;
            }
        }

        public override bool MoveRight()
        {
            if (Position.X + 2 > Map.Width)
            {
                Map.SetElement(new Empty(Position));
                Position position = Position;
                position.X = 0;
                Position = position;
                Map.SetElement(new Pacman(Map), Position);
                return true;
            }
            else
            {
                IFood food = Map.GetElementRight(Position) as IFood;
                if (food != null)
                    Eat(food);
                return base.MoveRight();
            }

        }

        public override bool MoveLeft()
        {
            if (Position.X - 1 < 0)
            {
                Map.SetElement(new Empty(Position));
                Position position = Position;
                position.X = Map.Height - 2;
                Position = position;
                Map.SetElement(new Pacman(Map), Position);
                return true;
            }
            else
            {
                IFood food = Map.GetElementLeft(Position) as IFood;
                if (food != null)
                    Eat(food);
                return base.MoveLeft();

            }
        }
        public override bool MoveDown()
        {
            IFood food = Map.GetElementDown(Position) as IFood;
            if (food != null)
                Eat(food);
            return base.MoveDown();
        }
        public override bool MoveUp()
        {
            IFood food = Map.GetElementUp(Position) as IFood;
            if (food != null)
                Eat(food);
            return base.MoveUp();
        }

        public override char GetCharElement()
        {
            return 'P';
        }
    }
}
