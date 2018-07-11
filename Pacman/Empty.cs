using PacMan.Interfaces;

namespace PacMan
{
    class Empty : ICoord
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
        public string GetId()
        {
            return "emtry";
        }
    }
}
