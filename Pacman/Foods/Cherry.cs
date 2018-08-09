using PacMan.Abstracts;
using PacMan.ExtensionClasses;
using PacMan.Interfaces;
using System;
using System.Timers;

namespace PacMan.Foods
{
    class Cherry : Food, ISinkMoving
    {
        private const int TIMELIFE = 10000;
        private readonly Timer _timer;

        public event Action<ICoord> Movement;
        private Map _map { get; set; }

        public Cherry(Position position, Map map) : base(position)
        {
            id = "cherry";
            idchar = '0';

            _map = map;
            Score = 100;
            _timer = new Timer(TIMELIFE);
        }

        public void Start()
        {
            _map[Position] = this;
            Movement(this);
            _timer.Start(TimerElapsed);
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            ((Timer)sender).Stop(TimerElapsed);
            if (IsLive)
            {
                _map[Position] = new Empty(Position);
                Movement(new Empty(Position));
            }
        }
    }
}
