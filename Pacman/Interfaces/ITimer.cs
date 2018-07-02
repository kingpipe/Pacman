using System.Timers;

namespace PacMan.Interfaces
{
    interface ITimer
    {
        void TimerElapsed(object sender, ElapsedEventArgs e);
        void Start(Timer timer);
        void Stop(Timer timer);
    }
}
