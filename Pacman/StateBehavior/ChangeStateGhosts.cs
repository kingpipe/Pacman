using System.Collections.Generic;
using System.Timers;
using PacMan.ExtensionClasses;
using PacMan.Interfaces;

namespace PacMan
{
    public class ChangeStateGhosts : ITimer
    {
        private readonly MenegerGhosts Ghosts;
        private readonly Timer timer;

        public Queue<int> Listoftime { get; set; }

        public ChangeStateGhosts(MenegerGhosts ghosts)
        {
            Ghosts = ghosts;
            Listoftime = new Queue<int>();
            InitQueue();
            timer = new Timer(Listoftime.Dequeue());
        }

        public ChangeStateGhosts(MenegerGhosts ghosts, Queue<int> Listoftime)
        {
            Ghosts = ghosts;
            timer = new Timer(Listoftime.Dequeue());
        }

        private void InitQueue()
        {
            Listoftime.Enqueue(7000);
            Listoftime.Enqueue(10000);
            Listoftime.Enqueue(7000);
            Listoftime.Enqueue(20000);
            Listoftime.Enqueue(5000);
            Listoftime.Enqueue(20000);
            Listoftime.Enqueue(5000);
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
            if (Listoftime.Count != 0)
                ((Timer)sender).Interval = Listoftime.Dequeue();
            else
                ((Timer)sender).Stop();
            Ghosts.State.ChangeBehavior(Ghosts);
        }
    }
}
