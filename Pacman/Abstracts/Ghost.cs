﻿using PacMan.Algorithms;
using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace PacMan.Abstracts
{
    abstract class Ghost : Player, IGhost, IFood
    {
        public abstract event Action SinkAboutKillPacman;

        protected bool pacmanIsLive = true;
        protected string idFrightened;
        protected Stack<Position> path;
                
        public IStrategy Strategy { get; set; }
        public IStrategy OldStrategy { get; set; }
        public ICoord OldCoord { get; set; }
        public Position PacmanPosition { get; set; }
        public bool Frightened { get; set; }
        public int DefaultScore { get; private set; }
        public int Score { get; set; }
        public bool IsLive { get; set; }
        public override Position StartCoord
        {
            get => start;
            set
            {
                start = value;
                StartPosition();
                OldCoord = new Empty(Position);
            }
        }

        protected Ghost(Map map, Position start) : base(map, start)
        {
            idFrightened = "frightened";
            Timer = new Timer();
            Strategy = new RandomMoving();
            path = new Stack<Position>();

            Score = 200;
            DefaultScore = Score;
            Frightened = false;
            IsLive = true;
        }

        public async void Restart()
        {
            StartPosition();
            DefaultTime();
            OldCoord = new Empty(Position);
            Strategy = OldStrategy;
            Frightened = false;
            await SleepAsync();
        }

        public override void Default(Map map)
        {
            base.Default(map);
            Strategy = new RandomMoving();
            OldCoord = new Empty(Position);
            Frightened = false;
            DefaultTime();
        }

        public void DefaultTime()
        {
            Timer.Interval = Time;
        }

        public void SpeedDownAt(double n)
        {
            Timer.Interval = Time * n;
        }

        public override string GetId()
        {
            if (Frightened)
            {
                return idFrightened;
            }
            else
            {
                return id;
            }
        }

        public override bool Move()
        {
            PacmanPosition = SearchPacman();

            if (PacmanPosition != Position)
            {
                path = Strategy.FindPath(Map, Position, PacmanPosition);
                OldCoord = Go(path, OldCoord);
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

        protected Position SearchPacman()
        {
            for (int y = 0; y < Map.Height; y++)
                for (int x = 0; x < Map.Width; x++)
                    if (Map.map[x, y] is IPacman)
                        return new Position(x, y);
            return PacmanPosition;
        }

        protected virtual ICoord Go(Stack<Position> list, ICoord coord)
        {
            lock (list)
            {
                if (list.Count == 0)
                {
                    return coord;
                }
                Position = list.Pop();
            }
            ICoord old = Map[Position];
            Map[coord.Position]=coord;
            Map[Position] = this;
            return old;
        }

        protected bool GhostIsFrightened()
        {
            if (Frightened)
            {
                return true;
            }
            else
            {
                OldCoord = new Empty(Position);
                return false;
            }
        }

        private async Task SleepAsync()
        {
            Timer.Stop();
            await Task.Delay(Time * 20);
            Timer.Start();
        }
    }
}
