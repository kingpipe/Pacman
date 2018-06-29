using PacMan.Abstracts;
using PacMan.Foods;
using PacMan.Interfaces;
using PacMan.Players;
using System;
using System.Collections.ObjectModel;
using System.Timers;

namespace PacMan
{
    public class ColectionGhosts
    {
        private Map Map { get; set; }
        public Collection<Ghost> Ghosts { get; set; }
        public Blinky Blinky { get; set; }
        public Clyde Clyde { get; set; }
        public Inky Inky { get; set; }

        public ColectionGhosts(Map map)
        {
            Map = map;

            Ghosts = new Collection<Ghost>();

            Blinky = new Blinky(map);
            Clyde = new Clyde(map);
            Inky = new Inky(map);

            AddGhostsInCollection();
        }

        public void SetGhosts()
        {
            Map.SetElement(new Clyde(Map));
            Map.SetElement(new Blinky(Map));
            Map.SetElement(new Inky(Map));
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
        }

        public void StopTimer(Timer timer)
        {
            foreach (var ghost in Ghosts)
            {
                ghost.Stop(timer);
            }
        }

        private void AddGhostsInCollection()
        {
            Ghosts.Add(Blinky);
            Ghosts.Add(Clyde);
            Ghosts.Add(Inky);
        }
    }
}
