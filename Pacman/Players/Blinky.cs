using System;
using System.Timers;
using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Players
{
    class Blinky : Ghost
    {
        public override event Action SinkAboutEatPacman;
        public override event Action<ICoord> Movement;

        public Blinky()
        { }

        public Blinky(Map map, int time) : base(map, time)
        {
            id = "blinky";
        }

        public override void StartPosition()
        {
            Position = new Position(15, 11);
        }

        public override void RemoveFromMap()
        {
            Map.SetElement(OldCoord);
            Movement(OldCoord);
        }

        public override void SetOnMap()
        {
            StartPosition();
            Map.SetElement(this);
            Movement(this);
        }

        public override void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Movement(OldCoord);
            pacmanIsLive = Move();
            Movement(Map.GetElement(Position));
            if (!pacmanIsLive)
            {
                SinkAboutEatPacman();
            }
        }

        public override char GetCharElement()
        {
            return 'B';
        }
    }
}
