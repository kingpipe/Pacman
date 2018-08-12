using System;
using System.Threading.Tasks;

namespace PacMan.Interfaces
{
    interface ISinkMoving
    {
        event Func<ICoord, Task> Movement;
    }
}
