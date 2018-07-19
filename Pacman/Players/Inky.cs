using PacMan.Abstracts;
using PacMan.Interfaces;
using System;
using System.Timers;

namespace PacMan.Players
{
    class Inky : Ghost
    {
        public override event Action SinkAboutEatPacman;
        public override event Action<ICoord> Movement;

        public Inky()
        { }

        public Inky(Map map, int time) : base(map, time)
        {
            id = "inky";
        }

        public override void StartPosition()
        {
            Position = new Position(13, 15);
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
            return 'I';
        }
    }
}
