using PacMan.Abstracts;
using PacMan.Interfaces;
using System;
using System.Timers;

namespace PacMan.Players
{
    class Pinky : Ghost, IGetChar
    {
        public override event Action SinkAboutEatPacman;
        public override event Action<ICoord> Movement;

        public Pinky(Map map, Position start) : base(map, start)
        {
            id = "pinky";
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
                SinkAboutEatPacman();
            }
        }

        public override char GetCharElement()
        {
            return 'N';
        }
    }
}
