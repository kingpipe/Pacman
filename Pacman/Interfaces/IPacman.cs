using PacMan.Enums;

namespace PacMan.Interfaces
{
    interface IPacman : IMovable, IEateble
    {
        int Lives { get; set; }
        int Count { get; set; }
        Direction Direction { get; set; }
        int Level { get; set; } 
    }
}
