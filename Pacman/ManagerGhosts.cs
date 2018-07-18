using PacMan.Abstracts;
using PacMan.Algorithms;
using PacMan.ExtensionClasses;
using PacMan.Interfaces;
using PacMan.Players;
using PacMan.StateBehavior;
using System;
using System.Collections.ObjectModel;
using System.Timers;

namespace PacMan
{
    class MenegerGhosts
    {
        private ChangeStateGhosts ChangeStateChosts { get; }
        private readonly Timer timeFrightened;

        public Map Map { get; set; }
        public Collection<Ghost> Ghosts { get; set; }
        public Blinky Blinky { get; set; }
        public Clyde Clyde { get; set; }
        public Inky Inky { get; set; }
        public Pinky Pinky { get; set; }
        public IState State { get; set; }

        public MenegerGhosts(Map map, int time)
        {
            timeFrightened = new Timer(10000);

            Map = map;

            Ghosts = new Collection<Ghost>();
            State = new StateScatter();
            Blinky = new Blinky(map, time);
            Clyde = new Clyde(map, time);
            Inky = new Inky(map, time);
            Pinky = new Pinky(map, time);

            AddGhostsInCollection();

            ChangeStateChosts = new ChangeStateGhosts(this);
        }
        public void SetDefaultMap(Map map)
        {
            Map = map;
            foreach (var ghost in Ghosts)
            {
                ghost.Map = map;
            }
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
                Map.SetElement(ghost);
                Map.SetElement(ghost.OldCoord);
                ghost.OldCoord = new Empty(ghost.Position);
            }
        }

        public void AreFrightened()
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

        public void StartPosition()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.StartPosition();
            }
        }

        public void RemoveGhosts()
        {
            foreach (var ghost in Ghosts)
            {
                Map.SetElement(new Empty(ghost.Position));
            }
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

        public void StartTimer()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.Start();
            }
            ChangeStateChosts.Start();
        }

        public void StopTimer()
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