using System.Collections.Generic;
using System.Timers;
using PacMan.ExtensionClasses;
using PacMan.Interfaces;
using PacMan.StateBehavior;

namespace PacMan
{
    class ChangeStateGhosts
    {
        public readonly MenagerGhosts Ghosts;
        public IState State { get; set; }

        private readonly Timer timer;
        private readonly Queue<int> listoftime;


        public ChangeStateGhosts(MenagerGhosts ghosts)
        {
            Ghosts = ghosts;
            listoftime = new Queue<int>();
            InitQueue();
            timer = new Timer(listoftime.Dequeue());
            State = new StateScatter();
        }

        private void InitQueue()
        {
            listoftime.Enqueue(10000);
            listoftime.Enqueue(20000);
            listoftime.Enqueue(7000);
            listoftime.Enqueue(20000);
            listoftime.Enqueue(5000);
            listoftime.Enqueue(20000);
            listoftime.Enqueue(5000);
        }

        public void Start()
        {
            timer.Start(TimerElapsed);
        }
        public void Stop()
        {
            timer.Stop(TimerElapsed);
        }

        public void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (listoftime.Count != 0)
            {
                ((Timer)sender).Interval = listoftime.Dequeue();
                State.ChangeBehavior(this);
            }
            else
            {
                ((Timer)sender).Stop();
                Ghosts.SetStrategyRunForPacman();
            }
        }
    }
}
