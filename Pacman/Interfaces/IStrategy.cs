using System.Collections.Generic;

namespace PacMan.Interfaces
{
    interface IStrategy
    {
        Stack<Position> FindPath(ICoord[,] map, Position start, Position goal);
    }
}
