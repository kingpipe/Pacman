using PacMan.Abstracts;
using PacMan.ExtensionClasses;
using PacMan.Interfaces;
using System;
using System.Timers;

namespace PacMan.Foods
{
    class Cherry : Food, IGetChar, ISinkMoving
    {
        private const int TIMELIFE = 10000;
        private readonly Timer timer;

        public event Action<ICoord> Movement;
        public Map Map { get; set; }

        public Cherry()
        { }

        public Cherry(Position position, Map map) : base(position)
        {
            Map = map;
            Score = 100;
            timer = new Timer(TIMELIFE);
        }

        public override char GetCharElement()
        {
            return '0';
        }

        public void Start()
        {
            Map.SetElement(this);
            Movement(this);
            timer.Start(TimerElapsed);
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            ((Timer)sender).Stop(TimerElapsed);
            if (IsLive)
            {
                Map.SetElement(new Empty(Position));
                Movement(new Empty(Position));
            }
        }
    }
}
