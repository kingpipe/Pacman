using System.Collections.Generic;
using System.Timers;
using PacMan.ExtensionClasses;
using PacMan.Interfaces;
using PacMan.StateBehavior;

namespace PacMan
{
    class ChangeStateGhosts
    {
        public MenagerGhosts Ghosts { get; }
        public IState State { get; set; }

        private readonly Timer _timer;
        private readonly Queue<int> _listoftime;


        public ChangeStateGhosts(MenagerGhosts ghosts)
        {
            Ghosts = ghosts;
            _listoftime = new Queue<int>();
            InitQueue();
            _timer = new Timer(_listoftime.Dequeue());
            State = new StateScatter();
        }

        private void InitQueue()
        {
            _listoftime.Enqueue(10000);
            _listoftime.Enqueue(20000);
            _listoftime.Enqueue(7000);
            _listoftime.Enqueue(20000);
            _listoftime.Enqueue(5000);
            _listoftime.Enqueue(20000);
            _listoftime.Enqueue(5000);
        }

        public void Start()
        {
            _timer.Start(TimerElapsed);
        }
        public void Stop()
        {
            _timer.Stop(TimerElapsed);
        }

        public void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            State.ChangeBehavior(this);
            if (_listoftime.Count != 0)
            {
                ((Timer)sender).Interval = _listoftime.Dequeue();
            }
            else
            {
                ((Timer)sender).Stop();
            }
        }
    }
}
