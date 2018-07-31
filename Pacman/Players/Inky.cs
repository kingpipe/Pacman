using PacMan.Abstracts;
using PacMan.Interfaces;
using System;
using System.Timers;

namespace PacMan.Players
{
    class Inky : Ghost
    {
        public override event Action SinkAboutKillPacman;
        public override event Action<ICoord> Movement;

        public Inky(Map map, Position start) : base(map, start)
        {
            id = "inky";
            idchar = 'I';
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
