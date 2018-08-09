using PacMan.Abstracts;
using PacMan.ExtensionClasses;
using PacMan.Interfaces;
using PacMan.Players;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Timers;

namespace PacMan
{
    class MenagerGhosts
    {
        private readonly Timer _timeFrightened;

        private ChangeStateGhosts _changeStateGhosts;
        private readonly Blinky _blinky;
        private readonly Clyde _clyde;
        private readonly Inky _inky;
        private readonly Pinky _pinky;
        private readonly Collection<Ghost> _ghosts;

        public MenagerGhosts(Map map, int time)
        {
            _timeFrightened = new Timer(10000);

            _ghosts = new Collection<Ghost>();
            _blinky = map.Blinky;
            _clyde = map.Clyde;
            _inky = map.Inky;
            _pinky = map.Pinky;

            AddGhostsInCollection();
            SetTime(time);

            _changeStateGhosts = new ChangeStateGhosts(this);
        }

        private void SetTime(int time)
        {
            foreach (var ghost in _ghosts)
            {
                ghost.SetTime(time);
            }
        }

        public void Default(Map map)
        {
            SetDefaultMap(map);
            _changeStateGhosts = new ChangeStateGhosts(this);
        }

        public void SetDefaultMap(Map map)
        {
            foreach (var ghost in _ghosts)
            {
                ghost.Default(map);
            }
        }

        public void SetStartCoord(Map map)
        {
            _inky.StartCoord = map.Inky.StartCoord;
            _pinky.StartCoord = map.Pinky.StartCoord;
            _clyde.StartCoord = map.Clyde.StartCoord;
            _blinky.StartCoord = map.Blinky.StartCoord;
        }

        public void EatGhost()
        {
            foreach (var ghost in _ghosts)
            {
                ghost.UpScore();
            }
        }

        public void StartPositions()
        {
            foreach (var ghost in _ghosts)
            {
                ghost.StartPosition();
            }
        }

        public void Start()
        {
            foreach (var ghost in _ghosts)
            {
                ghost.Start();
            }
            _changeStateGhosts.Start();
        }

        public void Stop()
        {
            foreach (var ghost in _ghosts)
            {
                ghost.Stop();
            }
            _changeStateGhosts.Stop();
        }

        public void AreFrightened()
        {
            _timeFrightened.Stop(Timer_Elapsed);
            foreach (var ghost in _ghosts)
            {
                if (ghost.IsLive)
                {
                    ghost.Scared();
                }
            }
            _timeFrightened.Start(Timer_Elapsed);
            _changeStateGhosts.Stop();
        }

        public void ArenotFrightened()
        {
            foreach (var ghost in _ghosts)
            {
                ghost.NotScared();
            }
            _timeFrightened.Stop(Timer_Elapsed);
            _changeStateGhosts.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ArenotFrightened();
        }

        public void AddSinkAboutEatPacmanHandler(Func<Task> action)
        {
            foreach (var ghost in _ghosts)
            {
                ghost.SinkAboutKillPacman += action;
            }
        }

        public void AddMoveHandler(Action<ICoord> action)
        {
            foreach (var ghost in _ghosts)
            {
                ghost.Movement += action;
            }
        }

        public void SetStrategyRunForPacman()
        {
            foreach (var ghost in _ghosts)
            {
                ghost.StrategyRunForPacman();
            }
        }

        public void SetStrategyGoToCorner()
        {
            foreach (var ghost in _ghosts)
            {
                ghost.StrategyGoToCorner();
            }
        }

        public void SetStrategyGoAway()
        {
            foreach (var ghost in _ghosts)
            {
                ghost.StrategyGoAway();
            }
        }

        private void AddGhostsInCollection()
        {
            _ghosts.Add(_blinky);
            _ghosts.Add(_clyde);
            _ghosts.Add(_inky);
            _ghosts.Add(_pinky);
        }
    }
}