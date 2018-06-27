using System.Collections.Generic;

namespace PacMan.Interfaces
{
    interface IStrategy
    {
        Stack<Position> FindPath(IMap map, Position start, Position goal);
    }
}
