using System.Collections.Generic;
using System.Timers;

namespace PacMan
{
    public class Time
    {
        private ColectionGhosts Ghosts;
        private Queue<int> listoftime;
        private Timer timer;
        public Time(ColectionGhosts ghosts)
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
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        public void Stop()
        {
            timer.Start();
            timer.Elapsed -= Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (listoftime.Count != 0)
                ((Timer)sender).Interval = listoftime.Dequeue();
            else
                ((Timer)sender).Stop();
            Ghosts.State.ChangeBehavior(Ghosts);
        }
    }
}
