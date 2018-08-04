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

        private ChangeStateGhosts changeStateGhosts;
        private readonly Blinky blinky;
        private readonly Clyde clyde;
        private readonly Inky inky;
        private readonly Pinky pinky;
        private readonly Collection<Ghost> ghosts;

        public MenagerGhosts(Map map, int time)
        {
            timeFrightened = new Timer(10000);

            ghosts = new Collection<Ghost>();
            blinky = map.Blinky;
            clyde = map.Clyde;
            inky = map.Inky;
            pinky = map.Pinky;

            AddGhostsInCollection();
            SetTime(time);

            changeStateGhosts = new ChangeStateGhosts(this);
        }

        private void SetTime(int time)
        {
            foreach (var ghost in ghosts)
            {
                ghost.SetTime(time);
            }
        }

        public void Default(Map map)
        {
            SetDefaultMap(map);
            changeStateGhosts = new ChangeStateGhosts(this);
        }

        public void SetDefaultMap(Map map)
        {
            foreach (var ghost in ghosts)
            {
                ghost.Default(map);
            }
        }

        public void SetStartCoord(Map map)
        {
            inky.StartCoord = map.Inky.StartCoord;
            pinky.StartCoord = map.Pinky.StartCoord;
            clyde.StartCoord = map.Clyde.StartCoord;
            blinky.StartCoord = map.Blinky.StartCoord;
        }

        public void EatGhost()
        {
            foreach (var ghost in ghosts)
            {
                ghost.UpScore();
            }
        }

        public void StartPositions()
        {
            foreach (var ghost in ghosts)
            {
                ghost.StartPosition();
            }
        }

        public void Start()
        {
            foreach (var ghost in ghosts)
            {
                ghost.Start();
            }
            changeStateGhosts.Start();
        }

        public void Stop()
        {
            foreach (var ghost in ghosts)
            {
                ghost.Stop();
            }
            changeStateGhosts.Stop();
        }

        public void AreFrightened()
        {
            timeFrightened.Stop(Timer_Elapsed);

            foreach (var ghost in ghosts)
            {
                ghost.Scared();
            }
            timeFrightened.Start(Timer_Elapsed);

            changeStateGhosts.Stop();
        }

        public void ArenotFrightened()
        {
            foreach (var ghost in ghosts)
            {
                ghost.NotScared();
            }
            timeFrightened.Stop(Timer_Elapsed);

            changeStateGhosts.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ArenotFrightened();
        }
        
        public void AddSinkAboutEatPacmanHandler(Func<Task> action)
        {
            foreach (var ghost in ghosts)
            {
                ghost.SinkAboutKillPacman += action;
            }
        }

        public void AddMoveHandler(Action<ICoord> action)
        {
            foreach (var ghost in ghosts)
            {
                ghost.Movement += action;
            }
        }

        public void SetStrategyRunForPacman()
        {
            foreach (var ghost in ghosts)
            {
                ghost.StrategyRunForPacman();
            }
        }

        public void SetStrategyGoToCorner()
        {
            foreach (var ghost in ghosts)
            {
                ghost.StrategyGoToCorner();
            }
        }

        public void SetStrategyGoAway()
        {
            foreach (var ghost in ghosts)
            {
                ghost.StrategyGoAway();
            }
        }
        
        private void AddGhostsInCollection()
        {
            ghosts.Add(blinky);
            ghosts.Add(clyde);
            ghosts.Add(inky);
            ghosts.Add(pinky);
        }
    }
}