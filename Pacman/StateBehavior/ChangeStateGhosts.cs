using System.Collections.Generic;
using System.Timers;
using PacMan.ExtensionClasses;
using PacMan.Interfaces;
using PacMan.Algorithms.Astar;

namespace PacMan
{
    class ChangeStateGhosts : ITimer
    {
        private readonly MenagerGhosts Ghosts;
        private readonly Timer timer;
        private readonly Queue<int> listoftime;

        public ChangeStateGhosts(MenagerGhosts ghosts)
        {
            Ghosts = ghosts;
            listoftime = new Queue<int>();
            InitQueue();
            timer = new Timer(listoftime.Dequeue());
        }

        public ChangeStateGhosts(MenagerGhosts ghosts, Queue<int> Listoftime)
        {
            Ghosts = ghosts;
            timer = new Timer(Listoftime.Dequeue());
        }

        private void InitQueue()
        {
            listoftime.Enqueue(7000);
            listoftime.Enqueue(10000);
            listoftime.Enqueue(7000);
            listoftime.Enqueue(10000);
            listoftime.Enqueue(5000);
            listoftime.Enqueue(10000);
            listoftime.Enqueue(5000);
            listoftime.Enqueue(10000);
            listoftime.Enqueue(3000);
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
                Ghosts.State.ChangeBehavior(Ghosts);
            }
            else
            {
                ((Timer)sender).Stop();
                Ghosts.SetStrategy(new AstarAlgorithm());
            }
        }
    }
}
