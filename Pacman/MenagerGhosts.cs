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
        private readonly Timer timeFrightened;

        private ChangeStateGhosts ChangeStateGhosts { set; get; }
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

            ChangeStateGhosts = new ChangeStateGhosts(this);
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
            ChangeStateGhosts = new ChangeStateGhosts(this);
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
                ghost.Default(map);
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
                ghost.UpScore();
            }
        }

        public void DefaultPositions()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.DefaultPosition();
            }
        }

        public void Start()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.Start();
            }
            ChangeStateGhosts.Start();
        }

        public void Stop()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.Stop();
            }
            ChangeStateGhosts.Stop();
        }

        public void AreFrightened()
        {
            timeFrightened.Stop(Timer_Elapsed);

            foreach (var ghost in Ghosts)
            {
                ghost.Scared();
            }
            timeFrightened.Start(Timer_Elapsed);

            ChangeStateGhosts.Stop();
        }

        public void ArenotFrightened()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.NotScared();
            }
            timeFrightened.Stop(Timer_Elapsed);

            ChangeStateGhosts.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ArenotFrightened();
        }
        
        public void AddSinkAboutEatPacmanHandler(Func<Task> action)
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
        
        private void AddGhostsInCollection()
        {
            Ghosts.Add(Blinky);
            Ghosts.Add(Clyde);
            Ghosts.Add(Inky);
            Ghosts.Add(Pinky);
        }
    }
}