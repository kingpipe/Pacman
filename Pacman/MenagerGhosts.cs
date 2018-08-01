using PacMan.Abstracts;
using PacMan.ExtensionClasses;
using PacMan.Interfaces;
using PacMan.Players;
using System;
using System.Collections.ObjectModel;
using System.Timers;

namespace PacMan
{
    class MenagerGhosts
    {
        private readonly Timer timeFrightened;

        private ChangeStateGhosts ChangeStateChosts { set; get; }
        private Blinky Blinky { get; set; }
        private Clyde Clyde { get; set; }
        private Inky Inky { get; set; }
        private Pinky Pinky { get; set; }
        private Collection<Ghost> Ghosts { get; set; }

        public MenagerGhosts(Map map, int time)
        {
            timeFrightened = new Timer(10000);

            Ghosts = new Collection<Ghost>();
            Blinky = map.Blinky;
            Clyde = map.Clyde;
            Inky = map.Inky;
            Pinky = map.Pinky;

            AddGhostsInCollection();
            SetTime(time);

            ChangeStateChosts = new ChangeStateGhosts(this);
        }

        private void SetTime(int time)
        {
            foreach (var ghost in Ghosts)
            {
                ghost.SetTime(time);
            }
        }

        public void Default(Map map)
        {
            ChangeStateChosts = new ChangeStateGhosts(this);
            foreach (var ghost in Ghosts)
            {
                ghost.Default(map);
            }
        }

        public void SetDefaultMap(Map map)
        {
            foreach (var ghost in Ghosts)
            {
                ghost.Map = map;
            }
        }

        public void SetStartCoord(Map map)
        {
            Inky.StartCoord = map.Inky.StartCoord;
            Pinky.StartCoord = map.Pinky.StartCoord;
            Clyde.StartCoord = map.Clyde.StartCoord;
            Blinky.StartCoord = map.Blinky.StartCoord;
        }

        public void EatGhost()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.Score += ghost.DefaultScore;
            }
        }

        public void SetGhosts()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.SetOnMap();
                ghost.OldCoord = new Empty(ghost.Position);
            }
        }

        public void RemoveGhosts()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.RemoveFromMap();
            }
        }

        public void Start()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.Start();
            }
            ChangeStateChosts.Start();
        }

        public void Stop()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.Stop();
            }
            ChangeStateChosts.Stop();
        }

        #region Frightened
        public void AreFrightened()
        {
            timeFrightened.Stop(Timer_Elapsed);

            foreach (var ghost in Ghosts)
            {
                ghost.Scared();
            }
            timeFrightened.Start(Timer_Elapsed);

            ChangeStateChosts.Stop();
        }

        public void ArenotFrightened()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.NotScared();
            }
            timeFrightened.Stop(Timer_Elapsed);

            ChangeStateChosts.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ArenotFrightened();
        }
        #endregion

        #region AddHandler
        public void AddSinkAboutEatPacmanHandler(Action action)
        {
            foreach (var ghost in Ghosts)
            {
                ghost.SinkAboutKillPacman += action;
            }
        }

        public void AddMoveHandler(Action<ICoord> action)
        {
            foreach (var ghost in Ghosts)
            {
                ghost.Movement += action;
            }
        }
        #endregion

        #region SetDifferentStrategy
        public void SetStrategyRunForPacman()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.StrategyRunForPacman();
            }
        }

        public void SetStrategyRandom()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.StrategyRandom();
            }
        }

        public void SetStrategyGoAway()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.StrategyGoAway();
            }
        }
        #endregion

        private void AddGhostsInCollection()
        {
            Ghosts.Add(Blinky);
            Ghosts.Add(Clyde);
            Ghosts.Add(Inky);
            Ghosts.Add(Pinky);
        }
    }
}