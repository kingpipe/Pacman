using System;
using System.Timers;
using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Players
{
    class Clyde : Ghost
    {
        public override event Action SinkAboutEatPacman;
        public override event Action<ICoord> Movement;

        public Clyde()
        { }

        public Clyde(Map map, int time) : base(map, time)
        {
            id = "clyde";
        }

        public override void StartPosition()
        {
            Position = new Position(15, 15);
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
            return 'C';
        }
    }
}
