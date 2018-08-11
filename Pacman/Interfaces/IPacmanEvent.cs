using System;

namespace PacMan.Interfaces
{
    interface IPacmanEvent
    {
        event Action SinkAboutCreateCherry;
        event Action SinkAboutEatEnergizer;
        event Action SinkAboutNextLevel;
        event Action SinkAboutEatGhost;
        event Action SinkAboutChangeScore;
    }
}
