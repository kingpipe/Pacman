using System.Timers;

namespace PacMan.ExtensionClasses
{
    public static class ExtensionTimer
    {
        public static void Start(this Timer timer, ElapsedEventHandler action)
        {
            timer.Elapsed += action;
            timer.Start();
        }

        public static void Stop(this Timer timer, ElapsedEventHandler action)
        {
            timer.Elapsed -= action;
            timer.Stop();
        }
    }
}
