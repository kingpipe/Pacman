using System;

namespace PacMan.Interfaces
{
    interface ISinkMoving
    {
        event Action<ICoord> Movement;
    }
}
