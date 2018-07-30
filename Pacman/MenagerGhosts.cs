using PacMan.Abstracts;
using PacMan.Algorithms;
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
        private ChangeStateGhosts ChangeStateChosts { set; get; }
        private readonly Timer timeFrightened;
        private Blinky Blinky { get; set; }
        private Clyde Clyde { get; set; }
        private Inky Inky { get; set; }
        private Pinky Pinky { get; set; }

        public Collection<Ghost> Ghosts { get; set; }

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

        public void Default(Map map)
        {
            ChangeStateChosts = new ChangeStateGhosts(this);
            foreach (var ghost in Ghosts)
            {
                ghost.Default(map);
             }
        }

        private void SetTime(int time)
        {
            foreach (var ghost in Ghosts)
            {
                ghost.SetTime(time);
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

        public void SetStrategy(IStrategy strategy)
        {
            foreach (var ghost in Ghosts)
            {
                ghost.Strategy = strategy;
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

        public void AreFrightened()
        {
            if (GhostsAlreadyFrightened())
            {
                timeFrightened.Stop(Timer_Elapsed);
                timeFrightened.Start(Timer_Elapsed);
            }
            else
            {
                foreach (var ghost in Ghosts)
                {
                    ghost.SpeedDownAt(1.5);
                    ghost.Frightened = true;
                    ghost.OldStrategy = ghost.Strategy;
                    ghost.Strategy = new GoAway();
                }
                timeFrightened.Start(Timer_Elapsed);
                ChangeStateChosts.Stop();
            }
        }

        private bool GhostsAlreadyFrightened()
        {
            foreach (var ghost in Ghosts)
            {
                if (ghost.Frightened)
                    return true;
            }
            return false;
        }

        public void ArenotFrightened()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.DefaultTime();
                ghost.Strategy = ghost.OldStrategy;
                ghost.Frightened = false;
            }
            timeFrightened.Stop(Timer_Elapsed);

            ChangeStateChosts.Start();
        }

        public void AddSinkAboutEatPacmanHandler(Action action)
        {
            foreach (var ghost in Ghosts)
            {
                ghost.SinkAboutEatPacman += action;
            }
        }

        public void AddMoveHandler(Action<ICoord> action)
        {
            foreach (var ghost in Ghosts)
            {
                ghost.Movement += action;
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

        private void AddGhostsInCollection()
        {
            Ghosts.Add(Blinky);
            Ghosts.Add(Clyde);
            Ghosts.Add(Inky);
            Ghosts.Add(Pinky);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ArenotFrightened();
        }
    }
}