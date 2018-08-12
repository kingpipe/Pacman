using PacMan.Algorithms;
using PacMan.Algorithms.Astar;
using PacMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace PacMan.Abstracts
{
    abstract class Ghost : Player, IGhost
    {
        protected abstract void GoToCircle();

        public event Func<Task> SinkAboutKillPacman;
        public override event Action<ICoord> Movement;

        public Position PacmanPosition { get; set; }
        public int Score { get; set; }
        public bool Frightened { get; set; }
        public bool IsLive { get; set; }

        protected bool pacmanIsLive;
        protected string idFrightened;
        protected string idEyes;
        protected string idCurrent;
        protected Stack<Position> path;
        protected Position homePosition;
        protected IStrategy Strategy { get; set; }
        protected IStrategy OldStrategy { get; set; }
        protected ICoord OldCoord { get; set; }
        protected int DefaultScore { get; private set; }
        protected override string Id
        {
            get => base.Id;
            set
            {
                base.Id = value;
                idCurrent = Id;
            }
        }

        private readonly object _obj = new object();

        protected Ghost(Position start, Map map) : base(start, map)
        {
            DefaultCoord();
            idFrightened = "frightened";
            idEyes = "eyes";
            path = new Stack<Position>();
            pacmanIsLive = true;
            StrategyGoToCorner();

            Score = 200;
            DefaultScore = Score;
            Frightened = false;
            IsLive = true;
        }

        public void UpScore() => Score += DefaultScore;
        public virtual void StrategyRunForPacman() => Strategy = new AstarAlgorithm();
        public void StrategyGoToCorner() => Strategy = new GoToCorner();

        public override void DefaultCoord()
        {
            base.DefaultCoord();
            OldCoord = new Empty(Position);
        }

        public override void StartPosition()
        {
            lock (_obj)
            {
                Map[OldCoord.Position] = OldCoord;
                Movement?.Invoke(OldCoord);

                DefaultCoord();
                Map[Position] = this;
                Movement?.Invoke(this);
            }
        }

        public override void Default(Map map)
        {
            base.Default(map);
            StrategyGoToCorner();
            OldCoord = new Empty(Position);
            Frightened = false;
            IsLive = true;
            idCurrent = Id;
            DefaultTime();
        }

        public override string GetId()
        {
            return idCurrent;
        }

        public override bool Move()
        {
            if (!IsLive)
            {
                path = Strategy.FindPath(Map, Position, StartCoord);
                if (Position == StartCoord)
                {
                    IsLive = true;
                    idCurrent = Id;
                    Strategy = OldStrategy;
                }
            }
            else
            {
                if (Strategy is GoToCorner)
                {
                    path = Strategy.FindPath(Map, Position, homePosition);
                    if (Position == homePosition)
                    {
                        GoToCircle();
                    }
                }
                else
                {
                    path = Strategy.FindPath(Map, Position, PacmanPosition);
                }
            }

            PacmanPosition = SearchPacman();

            if (PacmanPosition != Position)
            {
                OldCoord = Go(path, OldCoord);
                if (PacmanPosition != Position)
                {
                    return true;
                }
                return GhostCanKill();
            }
            else
            {
                return GhostCanKill();
            }
        }

        protected override void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            lock (_obj)
            {
                Movement.Invoke(OldCoord);
                pacmanIsLive = Move();
                Movement.Invoke(Map[Position]);
            }
            if (!pacmanIsLive)
            {
                SinkAboutKillPacman();
            }
        }

        public void Restart()
        {
            timer.Stop();
            DefaultTime();
            OldCoord = new Empty(Position);
            Strategy = new GoToDefaultPosition();
            Frightened = false;
            IsLive = false;
            idCurrent = idEyes;
            timer.Start();
        }

        public void Scared()
        {
            if (IsLive && !Frightened)
            {
                SpeedDownAt(2);
                Frightened = true;
                idCurrent = idFrightened;
                if (Strategy is GoToClockwise || Strategy is GoAgainstClockwise)
                {
                    Strategy = new GoToCorner();
                }
                OldStrategy = Strategy;
                Strategy = new GoAway();
            }
        }

        public void NotScared()
        {
            if (IsLive && Frightened)
            {
                DefaultTime();
                Strategy = OldStrategy;
                Frightened = false;
                idCurrent = Id;
                Score = DefaultScore;
            }
        }

        private Position SearchPacman()
        {
            for (int y = 0; y < Map.Height; y++)
                for (int x = 0; x < Map.Widht; x++)
                    if (Map.map[x, y] is IPacman)
                        return new Position(x, y);
            return PacmanPosition;
        }

        private ICoord Go(Stack<Position> list, ICoord coord)
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
            if (old is IGhost)
            {
                Position = coord.Position;
                return coord;
            }
            if (!(coord is IPacman))
            {
                Map[coord.Position] = coord;
            }
            if (!(Map[Position] is IPacman))
            {
                Map[Position] = this;
            }
            return old;
        }

        private bool GhostCanKill()
        {
            return Frightened || !IsLive;
        }

        private void DefaultTime() => timer.Interval = Time;
        private void SpeedDownAt(double n) => timer.Interval = Time * n;
    }
}