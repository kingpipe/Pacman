using PacMan.Algorithms;
using PacMan.Algorithms.Astar;
using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace PacMan.Abstracts
{
    abstract class Ghost : Player, IGhost, IFood
    {
        public abstract void StrategyGoToCorner();

        public event Func<Task> SinkAboutKillPacman;
        public override event Action<ICoord> Movement;

        protected bool pacmanIsLive;
        protected string idFrightened;
        protected Stack<Position> path;
        protected Position homePosition;
        protected IStrategy Strategy { get; set; }
        protected IStrategy OldStrategy { get; set; }
        protected ICoord OldCoord { get; set; }

        public bool Frightened { get; set; }
        public Position PacmanPosition { get; set; }
        protected int DefaultScore { get; private set; }
        public int Score { get; set; }
        public bool IsLive { get; set; }
        public override Position StartCoord
        {
            get => start;
            set
            {
                start = value;
                DefaultCoord();
                OldCoord = new Empty(Position);
            }
        }

        protected Ghost(Map map, Position start) : base(map, start)
        {
            idFrightened = "frightened";
            timer = new Timer();
            path = new Stack<Position>();
            pacmanIsLive = true;

            Score = 200;
            DefaultScore = Score;
            Frightened = false;
            IsLive = true;
        }

        public void UpScore() => Score += DefaultScore;
        public void StrategyGoAway() => Strategy = new GoAway();
        public virtual void StrategyRunForPacman() => Strategy = new AstarAlgorithm();

        public override void DefaultCoord()
        {
            base.DefaultCoord();
            OldCoord = new Empty(Position);
        }

        public override void StartPosition()
        {
            Map[OldCoord.Position] = OldCoord;
            Movement(OldCoord);

            DefaultCoord();
            Map[Position] = this;
            Movement(this);
        }

        public override void Default(Map map)
        {
            base.Default(map);
            StrategyGoToCorner();
            OldCoord = new Empty(Position);
            Frightened = false;
            DefaultTime();
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

        protected override void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Movement(OldCoord);
            pacmanIsLive = Move();
            Movement(Map[Position]);
            if (!pacmanIsLive)
            {
                SinkAboutKillPacman();
            }
        }

        public async void Died()
        {
            timer.Stop();
            DefaultCoord();
            DefaultTime();
            OldCoord = new Empty(Position);
            Strategy = OldStrategy;
            Frightened = false;
            await Task.Delay(Time * 20);
            timer.Start();
        }

        public void Scared()
        {
            SpeedDownAt(2);
            Frightened = true;
            OldStrategy = Strategy;
            StrategyGoAway();
        }

        public void NotScared()
        {
            DefaultTime();
            Strategy = OldStrategy;
            Frightened = false;
            Score = DefaultScore;
        }

        protected Position SearchPacman()
        {
            for (int y = 0; y < Map.Height; y++)
                for (int x = 0; x < Map.Widht; x++)
                    if (Map.map[x, y] is IPacman)
                        return new Position(x, y);
            return PacmanPosition;
        }

        protected ICoord Go(Stack<Position> list, ICoord coord)
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
            Map[coord.Position] = coord;
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

        private void DefaultTime() => timer.Interval = Time;
        private void SpeedDownAt(double n) => timer.Interval = Time * n;
    }
}