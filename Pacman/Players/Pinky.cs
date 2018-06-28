using PacMan.Abstracts;
using PacMan.Interfaces;
using System;
using System.Timers;

namespace PacMan.Players
{
    public class Pinky : Ghost
    {
        public override event Action SinkAboutEatPacman;
        public override event Action<ICoord> Moving;
        public override event Action<ICoord> Moved;

        public Pinky(Map map):base(map)
        {

        }

        protected override void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override bool Move()
        {
            throw new NotImplementedException();
        }

        public static char GetCharElement()
        {
            return 'N';
        }

    }
}
