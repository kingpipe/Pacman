using System;
using System.Threading.Tasks;

namespace PacMan.Interfaces
{
    interface IPacmanEvent
    {
        event Action SinkAboutCreateCherry;
        event Action SinkAboutEatEnergizer;
        event Action SinkAboutNextLevel;
        event Action SinkAboutEatGhost;
        event Func<Task> SinkAboutChangeScore;
    }
}
