using PacMan.Abstracts;
using PacMan.Interfaces;
using System;
using System.Timers;

namespace PacMan.Foods
{
    public class Cherry : Food, IGetChar, ISinkMoving
    {
        private readonly Timer timer;

        public event Action<ICoord> Movement;

        public Map Map { get; set; }
        public Cherry()
        { }

        public Cherry(Position position, Map map) : base(position)
        {
            Map = map;
            Score = 100;
            timer = new Timer(10000);
        }

        public override char GetCharElement()
        {
            return '0';
        }

        public void Start()
        {
            Map.SetElement(this);
            Movement(this);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ((Timer)sender).Stop();
            ((Timer)sender).Elapsed -= Timer_Elapsed;
            if (IsLive)
            {
                Map.SetElement(new Empty(Position));
                Movement(new Empty(Position));
            }
        }
    }
}
