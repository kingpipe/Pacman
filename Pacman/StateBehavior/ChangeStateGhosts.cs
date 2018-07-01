using System.Collections.Generic;
using System.Timers;
using PacMan.ExtensionClasses;

namespace PacMan
{
    public class ChangeStateGhosts
    {
        private ColectionGhosts Ghosts;
        private Queue<int> listoftime;
        private Timer timer;
        public ChangeStateGhosts(ColectionGhosts ghosts)
        {
            Ghosts=ghosts;
            listoftime = new Queue<int>();
            InitQueue();
            timer= new Timer(listoftime.Dequeue());
        }

        private void InitQueue()
        {
            listoftime.Enqueue(7000);
            listoftime.Enqueue(10000);
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
            timer.Start(TimerElapsed);
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (listoftime.Count != 0)
                ((Timer)sender).Interval = listoftime.Dequeue();
            else
                ((Timer)sender).Stop();
            Ghosts.State.ChangeBehavior(Ghosts);
        }
    }
}
