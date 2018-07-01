using PacMan.ExtensionClasses;
using PacMan.Abstracts;
using PacMan.Algorithms;
using PacMan.Foods;
using PacMan.Interfaces;
using PacMan.Players;
using PacMan.StateBehavior;
using System;
using System.Collections.ObjectModel;
using System.Timers;

namespace PacMan
{
    public class ColectionGhosts
    {
        private Map Map { get; set; }
        private ChangeStateGhosts ChangeStateChosts { get; }
        private Timer timer;
        public Collection<Ghost> Ghosts { get; set; }
        public Blinky Blinky { get; set; }
        public Clyde Clyde { get; set; }
        public Inky Inky { get; set; }
        public IState State { get; set; }
        
        public ColectionGhosts(Map map)
        {
            timer = new Timer(10000);

            Map = map;

            Ghosts = new Collection<Ghost>();
            State = new StateScatter();
            Blinky = new Blinky(map);
            Clyde = new Clyde(map);
            Inky = new Inky(map);

            AddGhostsInCollection();

            ChangeStateChosts = new ChangeStateGhosts(this);
        }

        public void SetGhosts()
        {
            foreach(var ghost in Ghosts)
            {
                Map.SetElement(ghost);
                ghost.oldcoord = new Empty(ghost.Position);
            }
        }

        public void GhostsAreFrightened()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.Frightened = true;
                ghost.strategy = new GoAway();
            }
            timer.Start(Timer_Elapsed);

            ChangeStateChosts.Stop();
        }

        public void GhostsArenotFrightened()
        {
            foreach (var ghost in Ghosts)
            {
                ghost.Frightened = false;
            }
            timer.Stop(Timer_Elapsed);

            ChangeStateChosts.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            GhostsArenotFrightened();
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

        public void RemoveSinkAboutEatPacmanHandler(Action action)
        {
            foreach (var ghost in Ghosts)
            {
                ghost.SinkAboutEatPacman -= action;
            }
        }

        public void AddMoveHandler(Action<ICoord> action)
        {
            foreach (var ghost in Ghosts)
            {
                ghost.Movement += action;
            }
        }

        public void StartTimer(Timer timer)
        {
            foreach (var ghost in Ghosts)
            {
                ghost.Start(timer);
            }
            ChangeStateChosts.Start();
        }

        public void StopTimer(Timer timer)
        {
            foreach (var ghost in Ghosts)
            {
                ghost.Stop(timer);
            }
            ChangeStateChosts.Stop();
        }

        private void AddGhostsInCollection()
        {
            Ghosts.Add(Blinky);
            Ghosts.Add(Clyde);
            Ghosts.Add(Inky);
        }
    }
}