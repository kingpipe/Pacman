using System;
using System.Timers;
using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan.Players
{
    class Clyde : Ghost, IGetChar
    {
        public override event Action SinkAboutEatPacman;
        public override event Action<ICoord> Movement;

        public Clyde()
        { }

        public Clyde(Map map, int time) : base(map, time)
        { }

        public override void StartPosition()
        {
            Position = new Position(14, 15);
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
