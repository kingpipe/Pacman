using System.Collections.Generic;

namespace PacMan.Interfaces
{
    public interface IStrategy
    {
        Stack<Position> FindPath(IMap map, Position start, Position goal);
    }
}
