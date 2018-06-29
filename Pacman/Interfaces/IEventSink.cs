using System;

namespace PacMan.Interfaces
{
    interface IEventSink
    {
        event Action SinkAboutEatPacman;
    }
}
