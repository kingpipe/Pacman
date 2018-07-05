using PacMan.Abstracts;
using PacMan.Interfaces;

namespace PacMan
{
    public class Empty : ICoord
    {
        public Position Position { get; set; }

        public Empty()
        { }

        public Empty(Position position)
        {
            Position = position;
        }

        public char GetCharElement()
        {
            return ' ';
        }
    }
}
