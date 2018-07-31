using System;
using System.Timers;
using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Players
{
    class Blinky : Ghost
    {
        public override event Action SinkAboutKillPacman;
        public override event Action<ICoord> Movement;

        public Blinky(Map map, Position start) : base(map, start)
        {
            id = "blinky";
            idchar = 'B';
        }

        public override void RemoveFromMap()
        {
            Map[OldCoord.Position] = OldCoord;
            Movement(OldCoord);
        }

        public override void SetOnMap()
        {
            StartPosition();
            Map[Position] = this;
            Movement(this);
        }

        public override void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Movement(OldCoord);
            pacmanIsLive = Move();
            Movement(Map[Position]);
            if (!pacmanIsLive)
            {
                SinkAboutKillPacman();
            }
        }
    }
}
