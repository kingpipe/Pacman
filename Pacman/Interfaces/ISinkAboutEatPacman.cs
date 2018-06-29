using System;

namespace PacMan.Interfaces
{
    interface ISinkAboutEatPacman : ISinkMoving
    {
        event Action SinkAboutEatPacman;
    }
}
