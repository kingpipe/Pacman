using Pacman.Interfaces;
using System;

namespace PacMan
{
    class Time
    {
        private DateTime time;
        public event Action EventAboutAttack;
        public event Action EventAboutScatter;
        public IState State;

        public void StartTime()
        {
            time = DateTime.Now;
        }
    }
}
