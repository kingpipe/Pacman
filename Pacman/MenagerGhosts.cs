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
            foreach (var ghost in _ghosts)
            {
                ghost.DefaultMap(map);
                ghost.StrategyGoToCorner();
            }
            _changeStateGhosts = new ChangeStateGhosts(this);
        }

        public void DefaultMap(Map map)
        {
            foreach (var ghost in _ghosts)
            {
                ghost.DefaultMap(map);
            }
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
            _changeStateGhosts.Stop();
            _timeFrightened.Stop(TimerElapsed);
            foreach (var ghost in _ghosts)
            {
                ghost.Scared();
            }
            _timeFrightened.Start(TimerElapsed);
        }

        public void AreNotFrightened()
        {
            foreach (var ghost in _ghosts)
            {
                ghost.NotScared();
            }
            _timeFrightened.Stop(TimerElapsed);
            _changeStateGhosts.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            AreNotFrightened();
        }

        public void AddSinkAboutEatPacmanHandler(Func<Task> action)
        {
            foreach (var ghost in _ghosts)
            {
                ghost.SinkAboutKillPacman += action;
            }
        }

        public void AddMoveHandler(Func<ICoord, Task> action)
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

        private void AddGhostsInCollection()
        {
            _ghosts.Add(_blinky);
            _ghosts.Add(_clyde);
            _ghosts.Add(_inky);
            _ghosts.Add(_pinky);
        }
    }
}