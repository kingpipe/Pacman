using System.Timers;

namespace PacMan.Interfaces
{
    interface ITimer
    {
        void TimerElapsed(object sender, ElapsedEventArgs e);
        void Start();
        void Stop();
    }
}
